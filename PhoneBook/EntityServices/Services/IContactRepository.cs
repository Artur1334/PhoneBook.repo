using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityServices
{
    public interface IContactRepository : IDisposable
    {
        IEnumerable<Contact> SelectAll();
        Contact Select(int? id);
        void Create(Contact item, ref int newid);
        void Update(Contact item);
        void Delete(int? id);
        void Save();
    }
}
