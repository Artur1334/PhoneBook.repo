using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityServices;

namespace InfrastructureData
{
    public class ContactRepository : IContactRepository

    {
        private PhoneEntity _phoneentity;
        private DbSet<Contact> _dbset;
        public ContactRepository()
        {
            this._phoneentity = new PhoneEntity();
            this._dbset = _phoneentity.Set<Contact>();
        }
//CREATE
        public void Create(Contact contact, ref int newid)
        {
            
            _dbset.Add(contact);
            _phoneentity.SaveChanges();

           newid = contact.ContactId;
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

            _phoneentity.Entry(contact).State = EntityState.Modified;
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
