namespace gmcscoServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Subscribe1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscribe", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscribe", "CreatedDate");
        }
    }
}
