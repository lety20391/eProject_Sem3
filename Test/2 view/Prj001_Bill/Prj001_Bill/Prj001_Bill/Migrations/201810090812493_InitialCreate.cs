namespace Prj001_Bill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        IDgenerate = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        UserPhone = c.String(nullable: false),
                        DetailAddress = c.String(nullable: false, maxLength: 200),
                        Product = c.String(nullable: false, maxLength: 200),
                        Note = c.String(maxLength: 200),
                        Info1 = c.String(),
                        Info2 = c.String(),
                        Info3 = c.String(),
                        Info4 = c.String(),
                    })
                .PrimaryKey(t => t.IDgenerate);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bill");
        }
    }
}
