namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPolicyEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "app.policies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenLastModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("app.policies");
        }
    }
}
