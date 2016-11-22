namespace EDeviceClaims.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedPolicyFieldLengths : DbMigration
    {
        public override void Up()
        {
            AddColumn("app.policies", "Number", c => c.String(nullable: false, maxLength: 20));
            AddColumn("app.policies", "SerialNumber", c => c.String(nullable: false, maxLength: 50));
            AddColumn("app.policies", "DeviceName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("app.policies", "CustomerEmail", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("app.policies", "CustomerEmail");
            DropColumn("app.policies", "DeviceName");
            DropColumn("app.policies", "SerialNumber");
            DropColumn("app.policies", "Number");
        }
    }
}
