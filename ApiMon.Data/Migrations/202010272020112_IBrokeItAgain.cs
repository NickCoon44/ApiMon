namespace ApiMon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IBrokeItAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElementType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeAdvantage",
                c => new
                    {
                        AdvantageId = c.Int(nullable: false),
                        DisadvantageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdvantageId, t.DisadvantageId })
                .ForeignKey("dbo.ElementType", t => t.AdvantageId)
                .ForeignKey("dbo.ElementType", t => t.DisadvantageId)
                .Index(t => t.AdvantageId)
                .Index(t => t.DisadvantageId);
            
            CreateTable(
                "dbo.Monster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ElementTypeId = c.Int(nullable: false),
                        MoveOneId = c.Int(),
                        MoveTwoId = c.Int(),
                        MoveThreeId = c.Int(),
                        MoveFourId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ElementType", t => t.ElementTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Move", t => t.MoveFourId)
                .ForeignKey("dbo.Move", t => t.MoveOneId)
                .ForeignKey("dbo.Move", t => t.MoveThreeId)
                .ForeignKey("dbo.Move", t => t.MoveTwoId)
                .Index(t => t.ElementTypeId)
                .Index(t => t.MoveOneId)
                .Index(t => t.MoveTwoId)
                .Index(t => t.MoveThreeId)
                .Index(t => t.MoveFourId);
            
            CreateTable(
                "dbo.Move",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ElementTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ElementType", t => t.ElementTypeId, cascadeDelete: true)
                .Index(t => t.ElementTypeId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveOneId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveFourId", "dbo.Move");
            DropForeignKey("dbo.Move", "ElementTypeId", "dbo.ElementType");
            DropForeignKey("dbo.Monster", "ElementTypeId", "dbo.ElementType");
            DropForeignKey("dbo.TypeAdvantage", "DisadvantageId", "dbo.ElementType");
            DropForeignKey("dbo.TypeAdvantage", "AdvantageId", "dbo.ElementType");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Move", new[] { "ElementTypeId" });
            DropIndex("dbo.Monster", new[] { "MoveFourId" });
            DropIndex("dbo.Monster", new[] { "MoveThreeId" });
            DropIndex("dbo.Monster", new[] { "MoveTwoId" });
            DropIndex("dbo.Monster", new[] { "MoveOneId" });
            DropIndex("dbo.Monster", new[] { "ElementTypeId" });
            DropIndex("dbo.TypeAdvantage", new[] { "DisadvantageId" });
            DropIndex("dbo.TypeAdvantage", new[] { "AdvantageId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Move");
            DropTable("dbo.Monster");
            DropTable("dbo.TypeAdvantage");
            DropTable("dbo.ElementType");
        }
    }
}
