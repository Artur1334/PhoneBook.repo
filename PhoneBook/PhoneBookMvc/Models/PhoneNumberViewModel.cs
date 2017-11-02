using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBookMvc.Models
{
    public class PhoneNumberViewModel
    {
        
        public int PhoneNumberId { get; set; }

        [MinLength(9, ErrorMessage = "Phone number must be at least 9 characters")]
        [MaxLength(20, ErrorMessage = "Phone number can have maximum 20 characters")]
        public string Number { get; set; }

        [Required]
        public int ContactId { get; set; }
    }
}