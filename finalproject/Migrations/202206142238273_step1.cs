namespace finalproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Adm_ID = c.Int(nullable: false, identity: true),
                        Adm_Name = c.String(),
                        Adm_UserName = c.String(),
                        Adm_Email = c.String(),
                        Adm_Password = c.String(),
                        Adm_Number1 = c.String(),
                        Adm_Number2 = c.String(),
                        AppUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Adm_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Benefactors",
                c => new
                    {
                        Ben_Id = c.Int(nullable: false, identity: true),
                        Ben_Name = c.String(nullable: false),
                        Ben_Number1 = c.String(nullable: false),
                        Ben_Number2 = c.String(nullable: false),
                        Ben_Email = c.String(nullable: false),
                        Ben_UserName = c.String(nullable: false),
                        Ben_Password = c.String(nullable: false),
                        Ben_Country = c.String(nullable: false),
                        Ben_Address = c.String(nullable: false),
                        Ben_sex = c.Int(nullable: false),
                        AppUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Ben_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.Children",
                c => new
                    {
                        Ch_ID = c.Int(nullable: false, identity: true),
                        Ch_Name = c.String(nullable: false),
                        Ch_PhoneNumber = c.String(nullable: false),
                        Ch_Age = c.Int(nullable: false),
                        Ch_DOB = c.DateTime(nullable: false),
                        Ch_Address = c.String(nullable: false),
                        Ch_Govrnate = c.String(nullable: false),
                        Ch_sex = c.Int(nullable: false),
                        Ch_PlaceBorn = c.String(nullable: false),
                        Ch_FatherName = c.String(nullable: false),
                        Ch_MotherName = c.String(nullable: false),
                        Ch_MotherDOB = c.DateTime(nullable: false),
                        Ch_DateFatherDeath = c.DateTime(nullable: false),
                        Ch_Image = c.String(nullable: false),
                        Volunteer_Vol_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Ch_ID)
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_Vol_ID)
                .Index(t => t.Volunteer_Vol_ID);
            
            CreateTable(
                "dbo.Dependants",
                c => new
                    {
                        Dep_id = c.String(nullable: false, maxLength: 128),
                        Dep_Name = c.String(nullable: false),
                        Dep_Age = c.Int(nullable: false),
                        Dep_DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Dep_id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Fl_ID = c.Int(nullable: false, identity: true),
                        Fl_Name = c.String(nullable: false),
                        Fl_Des = c.String(nullable: false),
                        Pr_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Fl_ID)
                .ForeignKey("dbo.Programs", t => t.Pr_Id, cascadeDelete: true)
                .Index(t => t.Pr_Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Pr_ID = c.Int(nullable: false, identity: true),
                        Pr_Type = c.String(nullable: false),
                        Pr_Name = c.String(nullable: false),
                        Pr_Descrition = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Pr_ID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Gr_Id = c.Int(nullable: false, identity: true),
                        Grade = c.Double(nullable: false),
                        Pr_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Gr_Id)
                .ForeignKey("dbo.Programs", t => t.Pr_Id, cascadeDelete: true)
                .Index(t => t.Pr_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Sounds",
                c => new
                    {
                        Sd_ID = c.Int(nullable: false, identity: true),
                        Sd_Name = c.String(nullable: false),
                        Sd_Des = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Sd_ID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Vid_ID = c.Int(nullable: false, identity: true),
                        Vid_Name = c.String(nullable: false),
                        Vid_Des = c.String(nullable: false),
                        Pr_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Vid_ID)
                .ForeignKey("dbo.Programs", t => t.Pr_Id, cascadeDelete: true)
                .Index(t => t.Pr_Id);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        Vol_ID = c.Int(nullable: false, identity: true),
                        Vol_Name = c.String(nullable: false),
                        Vol_UserName = c.String(nullable: false),
                        Vol_Password = c.String(nullable: false),
                        Vol_ConfirmPassword = c.String(nullable: false),
                        Vol_Govrnate = c.String(nullable: false),
                        Vol_Number1 = c.String(nullable: false),
                        Vol_Number2 = c.String(nullable: false),
                        Vol_Address = c.String(nullable: false),
                        Vol_email = c.String(nullable: false),
                        Vol_Sex = c.Int(nullable: false),
                        Vol_Job = c.String(),
                        Vol_Place = c.Boolean(nullable: false),
                        Vol_Skills = c.String(),
                        Vol_Certificates = c.String(),
                        AppUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Vol_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId)
                .Index(t => t.AppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Volunteers", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Children", "Volunteer_Vol_ID", "dbo.Volunteers");
            DropForeignKey("dbo.Videos", "Pr_Id", "dbo.Programs");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Grades", "Pr_Id", "dbo.Programs");
            DropForeignKey("dbo.Files", "Pr_Id", "dbo.Programs");
            DropForeignKey("dbo.Benefactors", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Admins", "AppUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Volunteers", new[] { "AppUserId" });
            DropIndex("dbo.Videos", new[] { "Pr_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Grades", new[] { "Pr_Id" });
            DropIndex("dbo.Files", new[] { "Pr_Id" });
            DropIndex("dbo.Children", new[] { "Volunteer_Vol_ID" });
            DropIndex("dbo.Benefactors", new[] { "AppUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Admins", new[] { "AppUserId" });
            DropTable("dbo.Volunteers");
            DropTable("dbo.Videos");
            DropTable("dbo.Sounds");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Grades");
            DropTable("dbo.Programs");
            DropTable("dbo.Files");
            DropTable("dbo.Dependants");
            DropTable("dbo.Children");
            DropTable("dbo.Benefactors");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Admins");
        }
    }
}
