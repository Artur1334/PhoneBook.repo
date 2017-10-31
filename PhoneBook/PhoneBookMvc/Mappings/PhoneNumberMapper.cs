using EntityServices.Models;
using PhoneBookMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookMvc.Mappings
{
    public static class PhoneNumberMapper
    {
        public static List<PhoneNumber> To_PhoneNumber_Create_ViewModel(this ContactCreateViewModel contactcreate ,int val)
        {
            List<PhoneNumber> listcontact = new List<PhoneNumber>();
            List<string> mylistphonenumber = new List<string> { contactcreate.phonenumber1, contactcreate.phonenumber2 ,contactcreate.phonenumber3};
            foreach (string item in mylistphonenumber)
            {
                if (item!=null)
                {
                    PhoneNumber contact = new PhoneNumber()
                    {
                        Number = item,
                        ContactId = val
                    };
                    listcontact.Add(contact);
                }
            }

            return listcontact;
        }
    }
}