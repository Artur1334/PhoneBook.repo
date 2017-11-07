namespace EntityServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertPhoneNumbers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO PhoneNumbers VALUES 
            ('091445562',(SELECT  ContactId FROM Contacts WHERE FirstName = 'Artur' AND Email = 'art.barseghyan@gmail.com')),
            ('077253645',(SELECT  ContactId FROM Contacts WHERE FirstName = 'Gevorg' AND Email = 'gev77@mail.ru')),
            ('096543985',(SELECT  ContactId FROM Contacts WHERE FirstName = 'Karen' AND Email = 'hovhannisyan.kar@yahoo.com')),
            ('087563214',(SELECT  ContactId FROM Contacts WHERE FirstName = 'Aram' AND Email = 'aramik06@list.ru')),
            ('098253495',(SELECT  ContactId FROM Contacts WHERE FirstName = 'Artur' AND Email = 'art.barseghyan@gmail.com')),
            ('077853416',(SELECT  ContactId FROM Contacts WHERE FirstName = 'Aram' AND Email = 'aramik06@list.ru')),
            ('055637548',(SELECT  ContactId FROM Contacts WHERE FirstName = 'Ani' AND Email = 'ani05.95@yandex.ru'))

");
        }
        
        public override void Down()
        {
        }
    }
}
