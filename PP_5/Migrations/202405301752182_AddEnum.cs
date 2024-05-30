namespace PP_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "root", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "root");
        }
    }
}
