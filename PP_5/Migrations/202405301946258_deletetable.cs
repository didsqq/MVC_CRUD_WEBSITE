namespace PP_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product_in_Order", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Product_in_Order", "ProductID", "dbo.Product");
            DropIndex("dbo.Product_in_Order", new[] { "ProductID" });
            DropIndex("dbo.Product_in_Order", new[] { "OrderID" });
            AddColumn("dbo.Order", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "ProductID");
            AddForeignKey("dbo.Order", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            DropTable("dbo.Product_in_Order");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Product_in_Order",
                c => new
                    {
                        Product_in_OrderID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Product_in_OrderID);
            
            DropForeignKey("dbo.Order", "ProductID", "dbo.Product");
            DropIndex("dbo.Order", new[] { "ProductID" });
            DropColumn("dbo.Order", "ProductID");
            CreateIndex("dbo.Product_in_Order", "OrderID");
            CreateIndex("dbo.Product_in_Order", "ProductID");
            AddForeignKey("dbo.Product_in_Order", "ProductID", "dbo.Product", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Product_in_Order", "OrderID", "dbo.Order", "OrderID", cascadeDelete: true);
        }
    }
}
