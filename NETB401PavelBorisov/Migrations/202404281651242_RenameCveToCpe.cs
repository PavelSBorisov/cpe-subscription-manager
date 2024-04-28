namespace NETB401PavelBorisov.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCveToCpe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubscriberCves", "Subscriber_Id", "dbo.Subscribers");
            DropForeignKey("dbo.SubscriberCves", "Cve_Id", "dbo.Cves");
            DropIndex("dbo.SubscriberCves", new[] { "Subscriber_Id" });
            DropIndex("dbo.SubscriberCves", new[] { "Cve_Id" });
            CreateTable(
                "dbo.Cpes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CpeId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscriberCpes",
                c => new
                    {
                        Subscriber_Id = c.Int(nullable: false),
                        Cpe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subscriber_Id, t.Cpe_Id })
                .ForeignKey("dbo.Subscribers", t => t.Subscriber_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cpes", t => t.Cpe_Id, cascadeDelete: true)
                .Index(t => t.Subscriber_Id)
                .Index(t => t.Cpe_Id);
            
            DropTable("dbo.Cves");
            DropTable("dbo.SubscriberCves");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubscriberCves",
                c => new
                    {
                        Subscriber_Id = c.Int(nullable: false),
                        Cve_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subscriber_Id, t.Cve_Id });
            
            CreateTable(
                "dbo.Cves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CveId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.SubscriberCpes", "Cpe_Id", "dbo.Cpes");
            DropForeignKey("dbo.SubscriberCpes", "Subscriber_Id", "dbo.Subscribers");
            DropIndex("dbo.SubscriberCpes", new[] { "Cpe_Id" });
            DropIndex("dbo.SubscriberCpes", new[] { "Subscriber_Id" });
            DropTable("dbo.SubscriberCpes");
            DropTable("dbo.Cpes");
            CreateIndex("dbo.SubscriberCves", "Cve_Id");
            CreateIndex("dbo.SubscriberCves", "Subscriber_Id");
            AddForeignKey("dbo.SubscriberCves", "Cve_Id", "dbo.Cves", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubscriberCves", "Subscriber_Id", "dbo.Subscribers", "Id", cascadeDelete: true);
        }
    }
}
