namespace EntityServices
{
    using EntityServices.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhoneEntity : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers{ get; set; }
        public PhoneEntity()
            : base("PhoneEntity")
        {
        }

    }

}