using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBookMvc.Models
{
    public class PhoneNumberViewModel
    {
        [Required]
        public int PhoneNumberId { get; set; }

        [Required]
        [MinLength(9,ErrorMessage ="Phone number must be at least 9 characters")]
        [MaxLength(20,ErrorMessage ="Phone number can have maximum 20 characters")]
        [RegularExpression("[0-9]")]
        public string Number { get; set; }

        [Required]
        public int ContactId { get; set; }
    }
}