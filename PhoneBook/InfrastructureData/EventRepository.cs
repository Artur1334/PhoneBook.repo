using EntityServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityServices.Models;
using EntityServices;
using System.Data.Entity;

namespace InfrastructureData
{
    public class EventRepository : IEventRepository
    {
        private PhoneEntity _phoneentity;
        private DbSet<Event> _dbset;

        public EventRepository()
        {
            this._phoneentity = new PhoneEntity();
            this._dbset = _phoneentity.Set<Event>();
        }

        //CREATE
        public void Create(Event ev)
        {

            _dbset.Add(ev);
            _phoneentity.SaveChanges();
        }

        //SAVE
        public void Save()
        {
            try
            {
                _phoneentity.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //SELECT
        public Event Select(int? id)
        {
            return _dbset.Find(id);
        }

        //SELECT ALL
        public IEnumerable<Event> SelectAll()
        {
            return _dbset.ToList();
        }

        public void Update(Event ev)
        {
            _dbset.Attach(ev);

            _phoneentity.Entry(ev).State = EntityState.Modified;
        }
        public void Delete(int? id)
        {
            Event DeleteInPhoneBook = _dbset.Find(id);
            _dbset.Remove(DeleteInPhoneBook);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
