namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createClaimsEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "app.claims",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
                        Notes = c.String(),
                        PolicyId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenLastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("app.policies", t => t.PolicyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.PolicyId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("app.claims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("app.claims", "PolicyId", "app.policies");
            DropIndex("app.claims", new[] { "UserId" });
            DropIndex("app.claims", new[] { "PolicyId" });
            DropTable("app.claims");
        }
    }
}
