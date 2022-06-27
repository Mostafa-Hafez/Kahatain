namespace finalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "Ch_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Grades", "Ch_Id");
            AddForeignKey("dbo.Grades", "Ch_Id", "dbo.Children", "Ch_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "Ch_Id", "dbo.Children");
            DropIndex("dbo.Grades", new[] { "Ch_Id" });
            DropColumn("dbo.Grades", "Ch_Id");
        }
    }
}
