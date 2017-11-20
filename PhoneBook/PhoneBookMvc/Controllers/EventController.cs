using EntityServices;
using EntityServices.Services;
using InfrastructureData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBookMvc.Controllers
{
    public class EventController : Controller
    {
        protected IContactRepository _contactrepository;

        protected IEventRepository _eventrepository;
        public EventController(ContactRepository contactrepository, EventRepository eventrepository)
        {
            this._contactrepository = contactrepository;
            this._eventrepository = eventrepository;
        }
    }
}