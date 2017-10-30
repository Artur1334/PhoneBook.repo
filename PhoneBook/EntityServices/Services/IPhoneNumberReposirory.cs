using EntityServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityServices.Services
{
   public interface IPhoneNumberReposirory:IDisposable
    {
        IEnumerable<PhoneNumber> SelectAll();
        PhoneNumber Select(int? id);
        void Create(PhoneNumber item);
        void Update(PhoneNumber item);
        void Delete(int? id);
        void Save();
    }
}
