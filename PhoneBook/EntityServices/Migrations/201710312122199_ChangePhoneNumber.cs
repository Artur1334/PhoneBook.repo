namespace EntityServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePhoneNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhoneNumbers", "Number", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhoneNumbers", "Number", c => c.String(nullable: false));
        }
    }
}
