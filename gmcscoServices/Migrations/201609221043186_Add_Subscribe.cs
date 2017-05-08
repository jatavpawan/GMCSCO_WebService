namespace gmcscoServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Subscribe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscribe",
                c => new
                    {
                        SubscriptionID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.SubscriptionID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribe");
        }
    }
}
