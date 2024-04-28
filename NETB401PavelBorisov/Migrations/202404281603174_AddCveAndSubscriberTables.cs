namespace NETB401PavelBorisov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCveAndSubscriberTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CveId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscriberCves",
                c => new
                    {
                        Subscriber_Id = c.Int(nullable: false),
                        Cve_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subscriber_Id, t.Cve_Id })
                .ForeignKey("dbo.Subscribers", t => t.Subscriber_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cves", t => t.Cve_Id, cascadeDelete: true)
                .Index(t => t.Subscriber_Id)
                .Index(t => t.Cve_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubscriberCves", "Cve_Id", "dbo.Cves");
            DropForeignKey("dbo.SubscriberCves", "Subscriber_Id", "dbo.Subscribers");
            DropIndex("dbo.SubscriberCves", new[] { "Cve_Id" });
            DropIndex("dbo.SubscriberCves", new[] { "Subscriber_Id" });
            DropTable("dbo.SubscriberCves");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Cves");
        }
    }
}
