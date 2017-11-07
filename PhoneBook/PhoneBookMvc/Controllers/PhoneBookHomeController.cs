using EntityServices;
using EntityServices.Models;
using EntityServices.Services;
using InfrastructureData;
using PhoneBookMvc.Mappings;
using PhoneBookMvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookMvc.Controllers
{
    public class PhoneBookHomeController : Controller
    {
        protected IContactRepository _contactrepository;

        protected IPhoneNumberReposirory _phonenumberrepository;

        public PhoneBookHomeController(ContactRepository repository, IPhoneNumberReposirory phonenumberrepository)
        {
            this._contactrepository = repository;
            this._phonenumberrepository = phonenumberrepository;
        }

        // GET: PhoneBookHomeController/Contact

        public ActionResult Contacts()
        {
            List<ContactViewModel> cantactsVM = _contactrepository.SelectAll().To_Contact_View_Model().ToList();

            return View(cantactsVM.OrderBy(a => a.FirstName));
        }

        // POST: PhoneBookHomeController/Contact

        [HttpPost]
        public ActionResult Contacts(string searchTerm)
        {
            List<ContactViewModel> cantactsVM = new List<ContactViewModel>();
            if (string.IsNullOrEmpty(searchTerm))
            {
                cantactsVM = _contactrepository.SelectAll().To_Contact_View_Model().ToList();
            }
            else
            {
                cantactsVM = _contactrepository.SelectAll().Where(a => a.FirstName.ToUpper().StartsWith(searchTerm.ToUpper())).To_Contact_View_Model().ToList();
            }

            return View(cantactsVM.OrderBy(a => a.FirstName));
        }

        // POST: PhoneBookHomeController/Autocomplete

        [HttpPost]
        public JsonResult Autocomplete(string Prefix)
        {
            List<string> str;

            str = _contactrepository.SelectAll().Where(a => a.FirstName.ToUpper().StartsWith(Prefix.ToUpper())).Select(b => b.FirstName).ToList();

            return Json(str, JsonRequestBehavior.AllowGet);
        }

        // POST: PhoneBookHomeController/NumberInfo

        public ActionResult NumberInfo(int? id)
        {
            List<PhoneNumber> _phonenumberlist = _phonenumberrepository.SelectAll().Where(d => d.ContactId == id).ToList();

            return View(_phonenumberlist);
        }

        // GET: PhoneBookHomeController/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneBookHomeController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCreateViewModel contactcreatevm, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Contact _contact = ContactsMapper.To_Contact_Create_ViewModel(contactcreatevm);
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadImg"), _FileName);
                        _contact.ImagePath = _FileName;
                        file.SaveAs(_path);
                    }

                }
                catch
                {
                    _contact.ImagePath = "images.png";

                }

                finally
                {
                    int val = 0;
                    _contactrepository.Create(_contact, ref val);
                    _contactrepository.Save();
                    List<PhoneNumber> _phonenumber = PhoneNumberMapper.To_PhoneNumber_Create_ViewModel(contactcreatevm, val).ToList();
                    foreach (PhoneNumber phonItem in _phonenumber)
                    {
                        _phonenumberrepository.Create(phonItem);
                        _phonenumberrepository.Save();
                    }

                }
                return RedirectToAction("Contacts");


            }
            return View("Create");
        }

        // GET: PhoneBookHomeController/Edit

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact _contact = _contactrepository.Select(id);
            List<PhoneNumber> _phonenumberlist = _phonenumberrepository.SelectAll().Where(d => d.ContactId == _contact.ContactId).ToList();
            ContactCreateViewModel contactVM = PhoneNumberMapper.To_Contact_Create_ViewModel(_phonenumberlist);
            contactVM.contactvm = ContactsMapper.To_Contact_View_Model(_contact);
            if (contactVM == null)
            {
                return HttpNotFound();
            }
            return View(contactVM);
        }

        // POST: PhoneBookHomeController/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactCreateViewModel contactvmNew, HttpPostedFileBase file)
        {
            try
            {
                Contact _con = ContactsMapper.To_Contact_Create_ViewModel(contactvmNew);
                if (file != null)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadImg"), _FileName);
                    _con.ImagePath = _FileName;
                    file.SaveAs(_path);
                }
                else
                {
                    _con.ImagePath = "images.png";
                }

                _contactrepository.Update(_con);
                _contactrepository.Save();
                List<PhoneNumber> _phonenumber = PhoneNumberMapper.To_PhoneNumber_Create_ViewModel(contactvmNew, _con.ContactId).ToList();
                foreach (PhoneNumber phonItem in _phonenumber)
                {

                    _phonenumberrepository.Update(phonItem);
                    _phonenumberrepository.Save();
                }
                return RedirectToAction("Contacts");
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again.");
            }
            return View(contactvmNew);

        }

        //  PhoneBookHomeController/Delete

        public JsonResult Delete(int? id)
        {
            bool result = false;
            Contact _contact = _contactrepository.Select(id);
            List<PhoneNumber> _phonenumberlist = _phonenumberrepository.SelectAll().Where(d => d.ContactId == id).ToList();
            if (_contact != null)
            {
                foreach (PhoneNumber item in _phonenumberlist)
                {
                    _phonenumberrepository.Delete(item.PhoneNumberId);
                    _phonenumberrepository.Save();
                }
                _contactrepository.Delete(id);
                _contactrepository.Save();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactrepository.Dispose();
                _contactrepository = null;
                _phonenumberrepository.Dispose();
                _phonenumberrepository = null;
            }
            base.Dispose(disposing);
        }
    }
}