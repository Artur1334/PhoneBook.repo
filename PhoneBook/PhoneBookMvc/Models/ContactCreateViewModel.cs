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
        [MinLength(9, ErrorMessage = "Phone number must be at least 9 characters")]
        [MaxLength(20, ErrorMessage = "Phone number can have maximum 20 characters")]
        [RegularExpression("[0-9]")]
        public string phonenumber1 { get; set; }

        [MinLength(9, ErrorMessage = "Phone number must be at least 9 characters")]
        [MaxLength(20, ErrorMessage = "Phone number can have maximum 20 characters")]
        [RegularExpression("[0-9]")]
        public string phonenumber2 { get; set; }

        [MinLength(9, ErrorMessage = "Phone number must be at least 9 characters")]
        [MaxLength(20, ErrorMessage = "Phone number can have maximum 20 characters")]
        [RegularExpression("[0-9]")]
        public string phonenumber3 { get; set; }

    }
}