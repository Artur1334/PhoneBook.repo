using EntityServices;
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
        protected IContactRepository _repository;
        public PhoneBookHomeController(ContactRepository repository)
        {
            this._repository = repository;
        }
        public ActionResult Contakts()
        {
            List<ContactViewModel> bankVM = _repository.SelectAll().To_Contact_View_Model().ToList();
            return View(bankVM);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
                _repository = null;
            }
            base.Dispose(disposing);
        }
    }
}