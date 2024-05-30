namespace PP_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Component_Type",
                c => new
                    {
                        Component_TypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Component_TypeID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                        Warranty_Period = c.Int(nullable: false),
                        ProviderID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Component_Type_Component_TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Component_Type", t => t.Component_Type_Component_TypeID)
                .ForeignKey("dbo.Provider", t => t.ProviderID, cascadeDelete: true)
                .Index(t => t.ProviderID)
                .Index(t => t.Component_Type_Component_TypeID);
            
            CreateTable(
                "dbo.Product_in_Order",
                c => new
                    {
                        Product_in_OrderID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Product_in_OrderID)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        Product_Count = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        ProviderID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ProviderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProviderID", "dbo.Provider");
            DropForeignKey("dbo.Product_in_Order", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Product_in_Order", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Product", "Component_Type_Component_TypeID", "dbo.Component_Type");
            DropIndex("dbo.Order", new[] { "CustomerID" });
            DropIndex("dbo.Product_in_Order", new[] { "OrderID" });
            DropIndex("dbo.Product_in_Order", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "Component_Type_Component_TypeID" });
            DropIndex("dbo.Product", new[] { "ProviderID" });
            DropTable("dbo.Provider");
            DropTable("dbo.Customer");
            DropTable("dbo.Order");
            DropTable("dbo.Product_in_Order");
            DropTable("dbo.Product");
            DropTable("dbo.Component_Type");
        }
    }
}
