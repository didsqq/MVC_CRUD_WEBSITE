namespace PP_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlmoneytodecimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Order", "Total_Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "Total_Amount");
            DropColumn("dbo.Product", "Price");
        }
    }
}
