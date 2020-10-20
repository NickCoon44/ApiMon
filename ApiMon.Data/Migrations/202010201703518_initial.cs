namespace ApiMon.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Monster", "ElementTypeId", "dbo.ElementType");
            DropForeignKey("dbo.Move", "ElementTypeId", "dbo.ElementType");
            DropForeignKey("dbo.Monster", "MoveFourId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveOneId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move");
            AddForeignKey("dbo.Monster", "ElementTypeId", "dbo.ElementType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Move", "ElementTypeId", "dbo.ElementType", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Monster", "MoveFourId", "dbo.Move", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Monster", "MoveOneId", "dbo.Move", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveOneId", "dbo.Move");
            DropForeignKey("dbo.Monster", "MoveFourId", "dbo.Move");
            DropForeignKey("dbo.Move", "ElementTypeId", "dbo.ElementType");
            DropForeignKey("dbo.Monster", "ElementTypeId", "dbo.ElementType");
            AddForeignKey("dbo.Monster", "MoveTwoId", "dbo.Move", "Id");
            AddForeignKey("dbo.Monster", "MoveThreeId", "dbo.Move", "Id");
            AddForeignKey("dbo.Monster", "MoveOneId", "dbo.Move", "Id");
            AddForeignKey("dbo.Monster", "MoveFourId", "dbo.Move", "Id");
            AddForeignKey("dbo.Move", "ElementTypeId", "dbo.ElementType", "Id");
            AddForeignKey("dbo.Monster", "ElementTypeId", "dbo.ElementType", "Id");
        }
    }
}
