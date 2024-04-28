namespace NETB401PavelBorisov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSubscriberTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubscriberCpes", "Subscriber_Id", "dbo.Subscribers");
            DropForeignKey("dbo.SubscriberCpes", "Cpe_Id", "dbo.Cpes");
            DropIndex("dbo.SubscriberCpes", new[] { "Subscriber_Id" });
            DropIndex("dbo.SubscriberCpes", new[] { "Cpe_Id" });
            AddColumn("dbo.Cpes", "SubscriberEmails", c => c.String());
            DropTable("dbo.Subscribers");
            DropTable("dbo.SubscriberCpes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubscriberCpes",
                c => new
                    {
                        Subscriber_Id = c.Int(nullable: false),
                        Cpe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subscriber_Id, t.Cpe_Id });
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Cpes", "SubscriberEmails");
            CreateIndex("dbo.SubscriberCpes", "Cpe_Id");
            CreateIndex("dbo.SubscriberCpes", "Subscriber_Id");
            AddForeignKey("dbo.SubscriberCpes", "Cpe_Id", "dbo.Cpes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubscriberCpes", "Subscriber_Id", "dbo.Subscribers", "Id", cascadeDelete: true);
        }
    }
}
