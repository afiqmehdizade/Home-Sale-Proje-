namespace FinalProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLikes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Likes", "UserId");
            CreateIndex("dbo.Likes", "AdvertId");
            AddForeignKey("dbo.Likes", "AdvertId", "dbo.Adverts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Likes", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Likes", "AdvertId", "dbo.Adverts");
            DropIndex("dbo.Likes", new[] { "AdvertId" });
            DropIndex("dbo.Likes", new[] { "UserId" });
        }
    }
}
