namespace gmcscoServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIpAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscribe", "IpAddress", c => c.String(maxLength: 35, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscribe", "IpAddress");
        }
    }
}
