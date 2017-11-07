namespace EntityServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertContacts : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Contacts 
                 VALUES ('Artur','Barseghyan','art.barseghyan@gmail.com','avatar-1.jpg','Komitas 55'),
                        ('Gevorg','Karapetyan','gev77@mail.ru','avatar-2.jpg','Mashtoc 24'),
                        ('Karen','Hovhannisyan','hovhannisyan.kar@yahoo.com','avatar-4.jpg','Xorenaci 5'),
                        ('Aram','Adamyan','aramik06@list.ru','avatar-6.jpg','Pushkini 7'),
                         ('Ani','Muradyan','ani05.95@yandex.ru','avatar-3.jpg','Baxramyan 26')");
        }
        
        public override void Down()
        {
        }
    }
}
