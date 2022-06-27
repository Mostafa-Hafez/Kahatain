namespace finalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "Volunteer_Vol_ID", "dbo.Volunteers");
            DropIndex("dbo.Children", new[] { "Volunteer_Vol_ID" });
            RenameColumn(table: "dbo.Children", name: "Volunteer_Vol_ID", newName: "Vol_ID");
            AlterColumn("dbo.Children", "Vol_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Children", "Vol_ID");
            AddForeignKey("dbo.Children", "Vol_ID", "dbo.Volunteers", "Vol_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "Vol_ID", "dbo.Volunteers");
            DropIndex("dbo.Children", new[] { "Vol_ID" });
            AlterColumn("dbo.Children", "Vol_ID", c => c.Int());
            RenameColumn(table: "dbo.Children", name: "Vol_ID", newName: "Volunteer_Vol_ID");
            CreateIndex("dbo.Children", "Volunteer_Vol_ID");
            AddForeignKey("dbo.Children", "Volunteer_Vol_ID", "dbo.Volunteers", "Vol_ID");
        }
    }
}
