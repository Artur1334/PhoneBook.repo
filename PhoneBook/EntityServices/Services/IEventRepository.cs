using EntityServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityServices.Services
{
  public  interface IEventRepository:IDisposable
    {
        IEnumerable<Event> SelectAll();
        Event Select(int? id);
        void Create(Event item);
        void Update(Event item);
        void Delete(int? id);
        void Save();
    }
}
