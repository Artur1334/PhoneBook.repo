namespace EntityServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.EventContacts",
                c => new
                    {
                        Event_EventID = c.Int(nullable: false),
                        Contact_ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventID, t.Contact_ContactId })
                .ForeignKey("dbo.Events", t => t.Event_EventID, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_ContactId, cascadeDelete: true)
                .Index(t => t.Event_EventID)
                .Index(t => t.Contact_ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventContacts", "Contact_ContactId", "dbo.Contacts");
            DropForeignKey("dbo.EventContacts", "Event_EventID", "dbo.Events");
            DropIndex("dbo.EventContacts", new[] { "Contact_ContactId" });
            DropIndex("dbo.EventContacts", new[] { "Event_EventID" });
            DropTable("dbo.EventContacts");
            DropTable("dbo.Events");
        }
    }
}
