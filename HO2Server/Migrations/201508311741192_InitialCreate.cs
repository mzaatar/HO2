namespace HO2Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendGroup",
                c => new
                    {
                        FriendGroupId = c.Int(nullable: false, identity: true),
                        FriendGroupName = c.String(nullable: false, maxLength: 100),
                        FriendGroupDetails = c.String(maxLength: 500),
                        FriendGroupAdminUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.FriendGroupId)
                .ForeignKey("dbo.User", t => t.FriendGroupAdminUser_UserId)
                .Index(t => t.FriendGroupAdminUser_UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        PlaceName = c.String(nullable: false, maxLength: 100),
                        Latitude = c.String(),
                        Longitude = c.String(),
                    })
                .PrimaryKey(t => t.PlaceId);
            
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        UpdateDateTime = c.DateTime(nullable: false),
                        SuggestedDateTime = c.DateTime(nullable: false),
                        FriendGroup_FriendGroupId = c.Int(nullable: false),
                        Place_PlaceId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.FriendGroup", t => t.FriendGroup_FriendGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Place", t => t.Place_PlaceId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.FriendGroup_FriendGroupId)
                .Index(t => t.Place_PlaceId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserFriendGroup",
                c => new
                    {
                        FriendGroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FriendGroupId, t.UserId })
                .ForeignKey("dbo.FriendGroup", t => t.FriendGroupId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.FriendGroupId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vote", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Vote", "Place_PlaceId", "dbo.Place");
            DropForeignKey("dbo.Vote", "FriendGroup_FriendGroupId", "dbo.FriendGroup");
            DropForeignKey("dbo.UserFriendGroup", "UserId", "dbo.User");
            DropForeignKey("dbo.UserFriendGroup", "FriendGroupId", "dbo.FriendGroup");
            DropForeignKey("dbo.FriendGroup", "FriendGroupAdminUser_UserId", "dbo.User");
            DropIndex("dbo.UserFriendGroup", new[] { "UserId" });
            DropIndex("dbo.UserFriendGroup", new[] { "FriendGroupId" });
            DropIndex("dbo.Vote", new[] { "User_UserId" });
            DropIndex("dbo.Vote", new[] { "Place_PlaceId" });
            DropIndex("dbo.Vote", new[] { "FriendGroup_FriendGroupId" });
            DropIndex("dbo.FriendGroup", new[] { "FriendGroupAdminUser_UserId" });
            DropTable("dbo.UserFriendGroup");
            DropTable("dbo.Vote");
            DropTable("dbo.Place");
            DropTable("dbo.User");
            DropTable("dbo.FriendGroup");
        }
    }
}
