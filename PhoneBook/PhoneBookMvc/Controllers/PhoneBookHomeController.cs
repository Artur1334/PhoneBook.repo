using EntityServices;
using EntityServices.Models;
using EntityServices.Services;
using InfrastructureData;
using PhoneBookMvc.Mappings;
using PhoneBookMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Contakts()
        {
            List<ContactViewModel> bankVM = _contactrepository.SelectAll().To_Contact_View_Model().ToList();
            return View(bankVM);
        }

        // GET: PhoneBookHomeController/Index
        public ActionResult Index()
        {
            return View();
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

                return RedirectToAction("Contakts");
            }

            return View("Create");
        }


        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
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