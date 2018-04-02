namespace TTAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Club",
                c => new
                    {
                        ClubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ClubId);
            
            CreateTable(
                "dbo.Equipament",
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
                "dbo.Match",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(nullable: false),
                        WinnerMatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Tournament", t => t.TournamentId, cascadeDelete: true)
                .Index(t => t.TournamentId);
            
            CreateTable(
                "dbo.Player",
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
                .ForeignKey("dbo.Match", t => t.Match_MatchId)
                .ForeignKey("dbo.Set", t => t.Set_SetId)
                .Index(t => t.Match_MatchId)
                .Index(t => t.Set_SetId);
            
            CreateTable(
                "dbo.Tournament",
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
                .ForeignKey("dbo.Player", t => t.Player_PlayerId)
                .Index(t => t.Player_PlayerId);
            
            CreateTable(
                "dbo.Set",
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
                .ForeignKey("dbo.Match", t => t.Match_MatchId)
                .Index(t => t.Match_MatchId);
            
            CreateTable(
                "dbo.Sponsor",
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
            DropForeignKey("dbo.Set", "Match_MatchId", "dbo.Match");
            DropForeignKey("dbo.Player", "Set_SetId", "dbo.Set");
            DropForeignKey("dbo.Player", "Match_MatchId", "dbo.Match");
            DropForeignKey("dbo.Tournament", "Player_PlayerId", "dbo.Player");
            DropForeignKey("dbo.Match", "TournamentId", "dbo.Tournament");
            DropIndex("dbo.Set", new[] { "Match_MatchId" });
            DropIndex("dbo.Tournament", new[] { "Player_PlayerId" });
            DropIndex("dbo.Player", new[] { "Set_SetId" });
            DropIndex("dbo.Player", new[] { "Match_MatchId" });
            DropIndex("dbo.Match", new[] { "TournamentId" });
            DropTable("dbo.Sponsor");
            DropTable("dbo.Set");
            DropTable("dbo.Tournament");
            DropTable("dbo.Player");
            DropTable("dbo.Match");
            DropTable("dbo.Equipament");
            DropTable("dbo.Club");
        }
    }
}
