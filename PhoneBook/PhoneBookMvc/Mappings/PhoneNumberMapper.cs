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
        public static PhoneNumberViewModel To_PhoneNumber_view_model(this PhoneNumber pn)
        {
            PhoneNumberViewModel pnvm = new PhoneNumberViewModel()
            {
                ContactId = pn.ContactId,
                Number = pn.Number,
                PhoneNumberId = pn.PhoneNumberId
            };
            return pnvm;
        }
        public static List<PhoneNumber> To_PhoneNumber_Create_ViewModel(this ContactCreateViewModel contactcreate ,int val)
        {
            List<PhoneNumber> listcontact = new List<PhoneNumber>();
            List<PhoneNumberViewModel> mylistphonenumber = new List<PhoneNumberViewModel> { contactcreate.phonenumber1, contactcreate.phonenumber2 ,contactcreate.phonenumber3};
            foreach (PhoneNumberViewModel item in mylistphonenumber)
            {
                if (item!=null&&item.Number!=null)
                {
                    PhoneNumber contact = new PhoneNumber()
                    {
                        Number = item.Number,
                        ContactId = val,
                        PhoneNumberId=item.PhoneNumberId
                        
                    };
                    listcontact.Add(contact);
                }
            }
            return listcontact;
        }


        public static ContactCreateViewModel To_Contact_Create_ViewModel(this List<PhoneNumber> contactcreate)
        {


            ContactCreateViewModel contactcreatevm = new ContactCreateViewModel();
            List<PhoneNumberViewModel> mynumberlist = new List<PhoneNumberViewModel>();
            foreach (PhoneNumber item in contactcreate)
            {
                mynumberlist.Add(item.To_PhoneNumber_view_model());
            }

            if (mynumberlist.Count>=1)
            {
                contactcreatevm.phonenumber1 = mynumberlist[0];
            }
            if (mynumberlist.Count >= 2)
            {
                contactcreatevm.phonenumber2 = mynumberlist[1];
            }
            if (mynumberlist.Count >= 3)
            {
                contactcreatevm.phonenumber3 = mynumberlist[2];
            }
            return contactcreatevm;
        }
    }
}