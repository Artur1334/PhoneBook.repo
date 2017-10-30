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
    public class PhoneNumberReposirory : IPhoneNumberReposirory
    {
        private PhoneEntity _phoneentity;
        private DbSet<PhoneNumber> _dbset;
        public PhoneNumberReposirory()
        {
            this._phoneentity = new PhoneEntity();
            this._dbset = _phoneentity.Set<PhoneNumber>();
        }
        public void Create(PhoneNumber phonnumber)
        {
            _dbset.Add(phonnumber);
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
        public PhoneNumber Select(int? id)
        {
            return _dbset.Find(id);
        }
//SELECTALL
        public IEnumerable<PhoneNumber> SelectAll()
        {
            return _dbset.ToList();
        }
//UPDATE
        public void Update(PhoneNumber item)
        {
            throw new NotImplementedException();
        }
//DELETE
        public void Delete(int? id)
        {
            PhoneNumber DeleteInPhoneBook = _dbset.Find(id);
            _dbset.Remove(DeleteInPhoneBook);
        }
//DISPOSE
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
