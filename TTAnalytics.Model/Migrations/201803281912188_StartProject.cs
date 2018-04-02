namespace TTAnalytics.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ClubId);
            
            CreateTable(
                "dbo.Equipaments",
                c => new
                    {
                        EquipamentId = c.Int(nullable: false, identity: true),
                        Paddle = c.String(),
                        FrontRubber = c.String(),
                        BackRubber = c.String(),
                        Activity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EquipamentId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(nullable: false),
                        WinnerMatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .Index(t => t.TournamentId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Activity = c.Boolean(nullable: false),
                        Handness = c.String(),
                        PlayingStyle = c.String(),
                        Grip = c.String(),
                        CurrentWRPosition = c.Int(nullable: false),
                        BestWRPosition = c.Int(nullable: false),
                        WRProgress = c.Int(nullable: false),
                        Match_MatchId = c.Int(),
                        Set_SetId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Matches", t => t.Match_MatchId)
                .ForeignKey("dbo.Sets", t => t.Set_SetId)
                .Index(t => t.Match_MatchId)
                .Index(t => t.Set_SetId);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        Kind = c.String(),
                        Organizer = c.String(),
                        Official = c.Boolean(nullable: false),
                        Player_PlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.TournamentId)
                .ForeignKey("dbo.Players", t => t.Player_PlayerId)
                .Index(t => t.Player_PlayerId);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        SetId = c.Int(nullable: false, identity: true),
                        PlayerAId = c.Int(nullable: false),
                        PlayerAPoints = c.Int(nullable: false),
                        PlayerBId = c.Int(nullable: false),
                        PlayerBPoints = c.Int(nullable: false),
                        WinnerId = c.Int(nullable: false),
                        Match_MatchId = c.Int(),
                    })
                .PrimaryKey(t => t.SetId)
                .ForeignKey("dbo.Matches", t => t.Match_MatchId)
                .Index(t => t.Match_MatchId);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        TypeSponsor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sets", "Match_MatchId", "dbo.Matches");
            DropForeignKey("dbo.Players", "Set_SetId", "dbo.Sets");
            DropForeignKey("dbo.Players", "Match_MatchId", "dbo.Matches");
            DropForeignKey("dbo.Tournaments", "Player_PlayerId", "dbo.Players");
            DropForeignKey("dbo.Matches", "TournamentId", "dbo.Tournaments");
            DropIndex("dbo.Sets", new[] { "Match_MatchId" });
            DropIndex("dbo.Tournaments", new[] { "Player_PlayerId" });
            DropIndex("dbo.Players", new[] { "Set_SetId" });
            DropIndex("dbo.Players", new[] { "Match_MatchId" });
            DropIndex("dbo.Matches", new[] { "TournamentId" });
            DropTable("dbo.Sponsors");
            DropTable("dbo.Sets");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Players");
            DropTable("dbo.Matches");
            DropTable("dbo.Equipaments");
            DropTable("dbo.Clubs");
        }
    }
}
