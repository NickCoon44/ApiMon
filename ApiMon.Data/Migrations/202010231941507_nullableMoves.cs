namespace ApiMon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableMoves : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Monster", "MoveFourId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveOneId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move");
            DropIndex("dbo.Monster", new[] { "MoveOneId" });
            DropIndex("dbo.Monster", new[] { "MoveTwoId" });
            DropIndex("dbo.Monster", new[] { "MoveThreeId" });
            DropIndex("dbo.Monster", new[] { "MoveFourId" });
            AlterColumn("dbo.Monster", "MoveOneId", c => c.Int());
            AlterColumn("dbo.Monster", "MoveTwoId", c => c.Int());
            AlterColumn("dbo.Monster", "MoveThreeId", c => c.Int());
            AlterColumn("dbo.Monster", "MoveFourId", c => c.Int());
            CreateIndex("dbo.Monster", "MoveOneId");
            CreateIndex("dbo.Monster", "MoveTwoId");
            CreateIndex("dbo.Monster", "MoveThreeId");
            CreateIndex("dbo.Monster", "MoveFourId");
            AddForeignKey("dbo.Monster", "MoveFourId", "dbo.Move", "Id");
            AddForeignKey("dbo.Monster", "MoveOneId", "dbo.Move", "Id");
            AddForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move", "Id");
            AddForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveOneId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveFourId", "dbo.Move");
            DropIndex("dbo.Monster", new[] { "MoveFourId" });
            DropIndex("dbo.Monster", new[] { "MoveThreeId" });
            DropIndex("dbo.Monster", new[] { "MoveTwoId" });
            DropIndex("dbo.Monster", new[] { "MoveOneId" });
            AlterColumn("dbo.Monster", "MoveFourId", c => c.Int(nullable: false));
            AlterColumn("dbo.Monster", "MoveThreeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Monster", "MoveTwoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Monster", "MoveOneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Monster", "MoveFourId");
            CreateIndex("dbo.Monster", "MoveThreeId");
            CreateIndex("dbo.Monster", "MoveTwoId");
            CreateIndex("dbo.Monster", "MoveOneId");
            AddForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Monster", "MoveOneId", "dbo.Move", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Monster", "MoveFourId", "dbo.Move", "Id", cascadeDelete: true);
        }
    }
}
