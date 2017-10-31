﻿using EntityServices;
using PhoneBookMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookMvc.Mappings
{
    public static class ContactsMapper
    {
        public static ContactViewModel To_Contact_View_Model(this Contact contact)
        {
            //ListDepositType ltd = new ListDepositType();
            ContactViewModel VMContact = new ContactViewModel()
            {
                Address=contact.Address,
                //ContactId=contact.ContactId,
                Email=contact.Email,
                FirstName=contact.FirstName,
                ImagePath=contact.ImagePath,
                LastName=contact.LastName
            };
            return VMContact;
        }
        public static IEnumerable<ContactViewModel> To_Contact_View_Model(this IEnumerable<Contact> contacts)
        {
            List<ContactViewModel> contactVM = new List<ContactViewModel>();
            foreach (var item in contacts)
            {
                contactVM.Add(item.To_Contact_View_Model());
            }
            return contactVM;
        }
        public static Contact To_Contact_Create_ViewModel(this ContactCreateViewModel contactcreate)
        {
            Contact contact = new Contact()
            {
              Address= contactcreate.contactvm.Address,
              Email= contactcreate.contactvm.Email,
              FirstName=contactcreate.contactvm.FirstName,
              ImagePath=contactcreate.contactvm.ImagePath,
              LastName=contactcreate.contactvm.LastName
            };
            return contact;
        }

    }
}