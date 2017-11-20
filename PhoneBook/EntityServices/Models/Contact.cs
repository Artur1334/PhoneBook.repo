using EntityServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityServices
{
    public class Contact
    {
        public Contact()
        {
            this.Events = new HashSet<Event>();
        }
        [Required]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        public string ImagePath { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
