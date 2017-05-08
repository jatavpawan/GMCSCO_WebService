namespace gmcscoServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactMessages",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 150, unicode: false),
                        LastName = c.String(maxLength: 150, unicode: false),
                        Company = c.String(maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                        PhoneNo = c.String(maxLength: 12, unicode: false),
                        Subject = c.String(maxLength: 150, unicode: false),
                        Msg = c.String(maxLength: 8000, unicode: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactMessages");
        }
    }
}
