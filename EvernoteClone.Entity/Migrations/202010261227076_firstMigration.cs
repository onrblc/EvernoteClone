namespace EvernoteClone.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModifiedBy = c.String(),
                        ObjectStatus = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 15),
                        DayOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Email = c.String(nullable: false, maxLength: 15),
                        Department = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModifiedBy = c.String(),
                        ObjectStatus = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotiId = c.Int(nullable: false),
                        Description = c.String(),
                        ContAction = c.String(),
                        UserId = c.Int(nullable: false),
                        NotificationStatus = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreatedBy = c.String(),
                        LastModifiedOn = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModifiedBy = c.String(),
                        ObjectStatus = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SessionTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notes", "User_Id", "dbo.Users");
            DropIndex("dbo.UserDetails", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "UserId" });
            DropIndex("dbo.Notes", new[] { "User_Id" });
            DropTable("dbo.UserDetails");
            DropTable("dbo.Notifications");
            DropTable("dbo.Users");
            DropTable("dbo.Notes");
        }
    }
}
