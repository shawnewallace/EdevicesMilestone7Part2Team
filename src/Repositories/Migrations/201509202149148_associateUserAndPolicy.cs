namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class associateUserAndPolicy : DbMigration
    {
        public override void Up()
        {
            AddColumn("app.policies", "AuthorizedUser_Id", c => c.String(maxLength: 128));
            CreateIndex("app.policies", "AuthorizedUser_Id");
            AddForeignKey("app.policies", "AuthorizedUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("app.policies", "AuthorizedUser_Id", "dbo.AspNetUsers");
            DropIndex("app.policies", new[] { "AuthorizedUser_Id" });
            DropColumn("app.policies", "AuthorizedUser_Id");
        }
    }
}
