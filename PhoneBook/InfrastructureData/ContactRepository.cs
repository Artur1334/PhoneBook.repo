using EntitiesServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Entities;
using System.Data.Entity;

namespace InfrastructureData
{
    public class ContactRepository : IContactRepository

    {
        private PhoneBookContext PhoneBookContext;
        private DbSet<Contact> _dbset;
        public ContactRepository()
        {
            this.PhoneBookContext = new PhoneBookContext();
            this._dbset = PhoneBookContext.Set<Contact>();
        }
//CREATE
        public void Create(Contact contact)
        {
            _dbset.Add(contact);
            PhoneBookContext.SaveChanges();
        }

//SAVE
        public void Save()
        {
            try
            {
                PhoneBookContext.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
//SELECT
        public Contact Select(int? id)
        {
            return _dbset.Find(id);
        }
//SELECTALL
        public IEnumerable<Contact> SelectAll()
        {
            return _dbset.ToList();
        }
        
//UPDATE
        public void Update(Contact contact)
        {
            _dbset.Attach(contact);

            PhoneBookContext.Entry(contact).State = EntityState.Modified;
        }
//DELETE
        public void Delete(int? id)
        {
            Contact DeleteInPhoneBook = _dbset.Find(id);
            _dbset.Remove(DeleteInPhoneBook);
        }
//DISPOSE
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
