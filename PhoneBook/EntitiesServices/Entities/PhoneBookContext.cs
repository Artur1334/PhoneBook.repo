namespace EntitiesServices.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext()
            : base("name=PhoneBookContext")
        {
        }
        public virtual DbSet<Contact> Contacts { get; set; }

    }
}