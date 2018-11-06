namespace keyOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false, maxLength: 255),
                        CustomerAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProcductId = c.Int(nullable: false, identity: true),
                        ProcductName = c.String(nullable: false, maxLength: 255),
                        ProcductPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProcductId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        DateSold = c.DateTime(nullable: false),
                        Products_ProcductId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Products_ProcductId)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.StoreId)
                .Index(t => t.Products_ProcductId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false, maxLength: 255),
                        StoreAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Sales", "Products_ProcductId", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Sales", new[] { "Products_ProcductId" });
            DropIndex("dbo.Sales", new[] { "StoreId" });
            DropIndex("dbo.Sales", new[] { "CustomerId" });
            DropTable("dbo.Stores");
            DropTable("dbo.Sales");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
