namespace PhotoSharingApplicacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        PhotoId = c.Int(nullable: false),
                        UserName = c.String(),
                        Subject = c.String(nullable: false, maxLength: 250),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        PhotoFile = c.Binary(),
                        ImageMimeType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.PhotoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PhotoId", "dbo.Photos");
            DropIndex("dbo.Comments", new[] { "PhotoId" });
            DropTable("dbo.Photos");
            DropTable("dbo.Comments");
        }
    }
}
