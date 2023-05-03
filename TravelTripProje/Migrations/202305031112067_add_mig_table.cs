namespace TravelTripProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mig_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Yorumlars", "BlogID", "dbo.Blogs");
            DropIndex("dbo.Yorumlars", new[] { "BlogID" });
            RenameColumn(table: "dbo.Yorumlars", name: "BlogID", newName: "Blog_BlogID");
            AlterColumn("dbo.Yorumlars", "Blog_BlogID", c => c.Int());
            CreateIndex("dbo.Yorumlars", "Blog_BlogID");
            AddForeignKey("dbo.Yorumlars", "Blog_BlogID", "dbo.Blogs", "BlogID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorumlars", "Blog_BlogID", "dbo.Blogs");
            DropIndex("dbo.Yorumlars", new[] { "Blog_BlogID" });
            AlterColumn("dbo.Yorumlars", "Blog_BlogID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Yorumlars", name: "Blog_BlogID", newName: "BlogID");
            CreateIndex("dbo.Yorumlars", "BlogID");
            AddForeignKey("dbo.Yorumlars", "BlogID", "dbo.Blogs", "BlogID", cascadeDelete: true);
        }
    }
}
