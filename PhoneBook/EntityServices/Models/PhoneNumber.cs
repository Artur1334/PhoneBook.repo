using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityServices.Models
{
    public class PhoneNumber
    {
        [Required]
        public int PhoneNumberId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Number{ get; set; }

        public Contact Contact { get; set; }

        [Required]
        public int ContactId { get; set; }
    }
}
