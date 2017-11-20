using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityServices.Models
{
   public class Event
    {
        public Event()
        {
            this.Contacts = new HashSet<Contact>();
        }
        [Required]
        public int EventID { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
