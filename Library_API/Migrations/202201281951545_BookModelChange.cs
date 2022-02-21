namespace Library_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookModelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.Books", "Colour_Id", "dbo.Colours");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropIndex("dbo.Books", new[] { "Colour_Id" });
            RenameColumn(table: "dbo.Books", name: "Author_Id", newName: "AuthorId");
            RenameColumn(table: "dbo.Books", name: "Colour_Id", newName: "ColourId");
            AlterColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "ColourId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "ColourId");
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "ColourId", "dbo.Colours", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "ColourId" });
            AlterColumn("dbo.Books", "ColourId", c => c.Int());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "ColourId", newName: "Colour_Id");
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Books", "Colour_Id");
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Books", "Colour_Id", "dbo.Colours", "Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
