namespace FinalProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adverts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        RoomCount = c.Int(nullable: false),
                        BedRoom = c.Int(nullable: false),
                        BathRoom = c.Int(nullable: false),
                        RoomArea = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        IsVip = c.Boolean(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        Image = c.String(maxLength: 200),
                        RentTypeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.RentTypes", t => t.RentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RentTypeId)
                .Index(t => t.UserId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SaleType = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 50),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 13),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 300),
                        ConfirmPassword = c.String(nullable: false, maxLength: 300),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UN_Email");
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UN_Email");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adverts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Adverts", "RentTypeId", "dbo.RentTypes");
            DropForeignKey("dbo.Adverts", "CityId", "dbo.Cities");
            DropIndex("dbo.Messages", "UN_Email");
            DropIndex("dbo.Users", "UN_Email");
            DropIndex("dbo.Adverts", new[] { "CityId" });
            DropIndex("dbo.Adverts", new[] { "UserId" });
            DropIndex("dbo.Adverts", new[] { "RentTypeId" });
            DropTable("dbo.Messages");
            DropTable("dbo.Users");
            DropTable("dbo.RentTypes");
            DropTable("dbo.Cities");
            DropTable("dbo.Adverts");
        }
    }
}
