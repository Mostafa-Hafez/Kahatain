namespace finalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dependants", "Ch_id", c => c.Int(nullable: false));
            AddColumn("dbo.Sounds", "Pr_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Dependants", "Ch_id");
            CreateIndex("dbo.Sounds", "Pr_Id");
            AddForeignKey("dbo.Dependants", "Ch_id", "dbo.Children", "Ch_ID", cascadeDelete: true);
            AddForeignKey("dbo.Sounds", "Pr_Id", "dbo.Programs", "Pr_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sounds", "Pr_Id", "dbo.Programs");
            DropForeignKey("dbo.Dependants", "Ch_id", "dbo.Children");
            DropIndex("dbo.Sounds", new[] { "Pr_Id" });
            DropIndex("dbo.Dependants", new[] { "Ch_id" });
            DropColumn("dbo.Sounds", "Pr_Id");
            DropColumn("dbo.Dependants", "Ch_id");
        }
    }
}
