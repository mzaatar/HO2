namespace HO2Server.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitRelease : DbMigration
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
                        FriendGroupAdminUser_MateId = c.Int(),
                    })
                .PrimaryKey(t => t.FriendGroupId)
                .ForeignKey("dbo.Mate", t => t.FriendGroupAdminUser_MateId)
                .Index(t => t.FriendGroupAdminUser_MateId);
            
            CreateTable(
                "dbo.Mate",
                c => new
                    {
                        MateId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MateId)
                .Index(t => t.Email, unique: true, name: "IX_UniqueEmail");
            
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
                        Mate_MateId = c.Int(nullable: false),
                        Place_PlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId)
                .ForeignKey("dbo.FriendGroup", t => t.FriendGroup_FriendGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Mate", t => t.Mate_MateId, cascadeDelete: true)
                .ForeignKey("dbo.Place", t => t.Place_PlaceId, cascadeDelete: true)
                .Index(t => t.FriendGroup_FriendGroupId)
                .Index(t => t.Mate_MateId)
                .Index(t => t.Place_PlaceId);
            
            CreateTable(
                "dbo.UserFriendGroup",
                c => new
                    {
                        FriendGroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FriendGroupId, t.UserId })
                .ForeignKey("dbo.FriendGroup", t => t.FriendGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Mate", t => t.UserId, cascadeDelete: true)
                .Index(t => t.FriendGroupId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vote", "Place_PlaceId", "dbo.Place");
            DropForeignKey("dbo.Vote", "Mate_MateId", "dbo.Mate");
            DropForeignKey("dbo.Vote", "FriendGroup_FriendGroupId", "dbo.FriendGroup");
            DropForeignKey("dbo.UserFriendGroup", "UserId", "dbo.Mate");
            DropForeignKey("dbo.UserFriendGroup", "FriendGroupId", "dbo.FriendGroup");
            DropForeignKey("dbo.FriendGroup", "FriendGroupAdminUser_MateId", "dbo.Mate");
            DropIndex("dbo.UserFriendGroup", new[] { "UserId" });
            DropIndex("dbo.UserFriendGroup", new[] { "FriendGroupId" });
            DropIndex("dbo.Vote", new[] { "Place_PlaceId" });
            DropIndex("dbo.Vote", new[] { "Mate_MateId" });
            DropIndex("dbo.Vote", new[] { "FriendGroup_FriendGroupId" });
            DropIndex("dbo.Mate", "IX_UniqueEmail");
            DropIndex("dbo.FriendGroup", new[] { "FriendGroupAdminUser_MateId" });
            DropTable("dbo.UserFriendGroup");
            DropTable("dbo.Vote");
            DropTable("dbo.Place");
            DropTable("dbo.Mate");
            DropTable("dbo.FriendGroup");
        }
    }
}
