namespace finalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Programs", "Pr_Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Programs", "Pr_Type", c => c.String(nullable: false));
        }
    }
}
