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
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Email = c.String(),
                        Location = c.String(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Paddle = c.String(),
                        FrontRubber = c.String(),
                        BackRubber = c.String(),
                        Activity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Handedness",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerA_Id = c.Int(),
                        PlayerB_Id = c.Int(),
                        Round_Id = c.Int(),
                        Tournament_Id = c.Int(),
                        Winner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Player", t => t.PlayerA_Id)
                .ForeignKey("dbo.Player", t => t.PlayerB_Id)
                .ForeignKey("dbo.Round", t => t.Round_Id)
                .ForeignKey("dbo.Tournament", t => t.Tournament_Id)
                .ForeignKey("dbo.Player", t => t.Winner_Id)
                .Index(t => t.PlayerA_Id)
                .Index(t => t.PlayerB_Id)
                .Index(t => t.Round_Id)
                .Index(t => t.Tournament_Id)
                .Index(t => t.Winner_Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Club_Id = c.Int(),
                        Country_Id = c.Int(),
                        Gender_Id = c.Int(),
                        Grip_Id = c.Int(),
                        Handedness_Id = c.Int(),
                        PlayingStyle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Club", t => t.Club_Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .ForeignKey("dbo.Gender", t => t.Gender_Id)
                .ForeignKey("dbo.Grip", t => t.Grip_Id)
                .ForeignKey("dbo.Handedness", t => t.Handedness_Id)
                .ForeignKey("dbo.PlayingStyle", t => t.PlayingStyle_Id)
                .Index(t => t.Club_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Gender_Id)
                .Index(t => t.Grip_Id)
                .Index(t => t.Handedness_Id)
                .Index(t => t.PlayingStyle_Id);
            
            CreateTable(
                "dbo.PlayingStyle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Round",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tournament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Type = c.String(),
                        Kind = c.String(),
                        Official = c.Boolean(nullable: false),
                        Organizer_Id = c.Int(),
                        Venue_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizer", t => t.Organizer_Id)
                .ForeignKey("dbo.Venue", t => t.Venue_Id)
                .Index(t => t.Organizer_Id)
                .Index(t => t.Venue_Id);
            
            CreateTable(
                "dbo.Organizer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        State_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Set",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScorePlayerA = c.Int(nullable: false),
                        ScorePlayerB = c.Int(nullable: false),
                        Match_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Match", t => t.Match_Id)
                .Index(t => t.Match_Id);
            
            CreateTable(
                "dbo.Sponsor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        TypeSponsor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Token = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Set", "Match_Id", "dbo.Match");
            DropForeignKey("dbo.Match", "Winner_Id", "dbo.Player");
            DropForeignKey("dbo.Match", "Tournament_Id", "dbo.Tournament");
            DropForeignKey("dbo.Tournament", "Venue_Id", "dbo.Venue");
            DropForeignKey("dbo.Venue", "State_Id", "dbo.State");
            DropForeignKey("dbo.State", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.Tournament", "Organizer_Id", "dbo.Organizer");
            DropForeignKey("dbo.Match", "Round_Id", "dbo.Round");
            DropForeignKey("dbo.Match", "PlayerB_Id", "dbo.Player");
            DropForeignKey("dbo.Match", "PlayerA_Id", "dbo.Player");
            DropForeignKey("dbo.Player", "PlayingStyle_Id", "dbo.PlayingStyle");
            DropForeignKey("dbo.Player", "Handedness_Id", "dbo.Handedness");
            DropForeignKey("dbo.Player", "Grip_Id", "dbo.Grip");
            DropForeignKey("dbo.Player", "Gender_Id", "dbo.Gender");
            DropForeignKey("dbo.Player", "Country_Id", "dbo.Country");
            DropForeignKey("dbo.Player", "Club_Id", "dbo.Club");
            DropForeignKey("dbo.Club", "Country_Id", "dbo.Country");
            DropIndex("dbo.Set", new[] { "Match_Id" });
            DropIndex("dbo.State", new[] { "Country_Id" });
            DropIndex("dbo.Venue", new[] { "State_Id" });
            DropIndex("dbo.Tournament", new[] { "Venue_Id" });
            DropIndex("dbo.Tournament", new[] { "Organizer_Id" });
            DropIndex("dbo.Player", new[] { "PlayingStyle_Id" });
            DropIndex("dbo.Player", new[] { "Handedness_Id" });
            DropIndex("dbo.Player", new[] { "Grip_Id" });
            DropIndex("dbo.Player", new[] { "Gender_Id" });
            DropIndex("dbo.Player", new[] { "Country_Id" });
            DropIndex("dbo.Player", new[] { "Club_Id" });
            DropIndex("dbo.Match", new[] { "Winner_Id" });
            DropIndex("dbo.Match", new[] { "Tournament_Id" });
            DropIndex("dbo.Match", new[] { "Round_Id" });
            DropIndex("dbo.Match", new[] { "PlayerB_Id" });
            DropIndex("dbo.Match", new[] { "PlayerA_Id" });
            DropIndex("dbo.Club", new[] { "Country_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Sponsor");
            DropTable("dbo.Set");
            DropTable("dbo.State");
            DropTable("dbo.Venue");
            DropTable("dbo.Organizer");
            DropTable("dbo.Tournament");
            DropTable("dbo.Round");
            DropTable("dbo.PlayingStyle");
            DropTable("dbo.Player");
            DropTable("dbo.Match");
            DropTable("dbo.Handedness");
            DropTable("dbo.Grip");
            DropTable("dbo.Gender");
            DropTable("dbo.Equipament");
            DropTable("dbo.Country");
            DropTable("dbo.Club");
        }
    }
}
