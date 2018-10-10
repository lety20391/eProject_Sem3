namespace Prj001_Bill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        IDgenerate = c.Int(nullable: false, identity: true),
                        IDProduct = c.Int(nullable: false),
                        productContent = c.String(nullable: false, maxLength: 100),
                        Info1 = c.String(),
                        Info2 = c.String(),
                        Info3 = c.String(),
                        Info4 = c.String(),
                    })
                .PrimaryKey(t => t.IDgenerate);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product");
        }
    }
}
