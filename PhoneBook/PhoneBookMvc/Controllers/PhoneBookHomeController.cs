using EntityServices;
using EntityServices.Models;
using EntityServices.Services;
using InfrastructureData;
using PhoneBookMvc.Mappings;
using PhoneBookMvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public ActionResult Contacts()
        {
            List<ContactViewModel> bankVM = _contactrepository.SelectAll().To_Contact_View_Model().ToList();
            return View(bankVM);
        }

        // GET: PhoneBookHomeController/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneBookHomeController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCreateViewModel contactcreatevm)
        {
            if (ModelState.IsValid)
            {
                Contact _contact = ContactsMapper.To_Contact_Create_ViewModel(contactcreatevm);
                int val = 0;
                _contactrepository.Create(_contact, ref val);
                _contactrepository.Save();
               List<PhoneNumber> _phonenumber = PhoneNumberMapper.To_PhoneNumber_Create_ViewModel(contactcreatevm, val ).ToList();
                foreach (PhoneNumber phonItem in _phonenumber)
                {
                    _phonenumberrepository.Create(phonItem);
                    _phonenumberrepository.Save();
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
        public ActionResult Edit(/*[Bind(Include = "Number,ContactId,PhoneNumberId")]*/ ContactCreateViewModel contactvmNew)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Contact _con = ContactsMapper.To_Contact_Create_ViewModel(contactvmNew);
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
            if (_contact!=null)
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