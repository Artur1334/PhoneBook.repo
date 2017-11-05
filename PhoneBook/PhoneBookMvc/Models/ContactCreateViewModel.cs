using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBookMvc.Models
{
    public class ContactCreateViewModel
    {
        [Required]
        public ContactViewModel contactvm { get; set; }

        [Required(ErrorMessage = "Phone number is Required")]
        public PhoneNumberViewModel phonenumber1 { get; set; }

        public PhoneNumberViewModel phonenumber2 { get; set; }
 
        public PhoneNumberViewModel phonenumber3 { get; set; }

    }
}