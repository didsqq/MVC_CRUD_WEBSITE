namespace PP_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "Component_Type_Component_TypeID", "dbo.Component_Type");
            DropIndex("dbo.Product", new[] { "Component_Type_Component_TypeID" });
            RenameColumn(table: "dbo.Product", name: "Component_Type_Component_TypeID", newName: "Component_TypeID");
            AlterColumn("dbo.Product", "Component_TypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "Component_TypeID");
            AddForeignKey("dbo.Product", "Component_TypeID", "dbo.Component_Type", "Component_TypeID", cascadeDelete: true);
            DropColumn("dbo.Product", "TypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "TypeID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product", "Component_TypeID", "dbo.Component_Type");
            DropIndex("dbo.Product", new[] { "Component_TypeID" });
            AlterColumn("dbo.Product", "Component_TypeID", c => c.Int());
            RenameColumn(table: "dbo.Product", name: "Component_TypeID", newName: "Component_Type_Component_TypeID");
            CreateIndex("dbo.Product", "Component_Type_Component_TypeID");
            AddForeignKey("dbo.Product", "Component_Type_Component_TypeID", "dbo.Component_Type", "Component_TypeID");
        }
    }
}
