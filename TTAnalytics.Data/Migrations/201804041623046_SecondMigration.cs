namespace TTAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tournament", "Player_Id", "dbo.Player");
            DropIndex("dbo.Tournament", new[] { "Player_Id" });
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
                "dbo.PlayingStyle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Player", "Gender_Id", c => c.Int());
            AddColumn("dbo.Player", "Grip_Id", c => c.Int());
            AddColumn("dbo.Player", "Handedness_Id", c => c.Int());
            AddColumn("dbo.Player", "PlayingStyle_Id", c => c.Int());
            CreateIndex("dbo.Player", "Gender_Id");
            CreateIndex("dbo.Player", "Grip_Id");
            CreateIndex("dbo.Player", "Handedness_Id");
            CreateIndex("dbo.Player", "PlayingStyle_Id");
            AddForeignKey("dbo.Player", "Gender_Id", "dbo.Gender", "Id");
            AddForeignKey("dbo.Player", "Grip_Id", "dbo.Grip", "Id");
            AddForeignKey("dbo.Player", "Handedness_Id", "dbo.Handedness", "Id");
            AddForeignKey("dbo.Player", "PlayingStyle_Id", "dbo.PlayingStyle", "Id");
            DropColumn("dbo.Player", "Gender");
            DropColumn("dbo.Player", "Activity");
            DropColumn("dbo.Player", "Handness");
            DropColumn("dbo.Player", "PlayingStyle");
            DropColumn("dbo.Player", "Grip");
            DropColumn("dbo.Player", "CurrentWRPosition");
            DropColumn("dbo.Player", "BestWRPosition");
            DropColumn("dbo.Player", "WRProgress");
            DropColumn("dbo.Tournament", "Player_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tournament", "Player_Id", c => c.Int());
            AddColumn("dbo.Player", "WRProgress", c => c.Int(nullable: false));
            AddColumn("dbo.Player", "BestWRPosition", c => c.Int(nullable: false));
            AddColumn("dbo.Player", "CurrentWRPosition", c => c.Int(nullable: false));
            AddColumn("dbo.Player", "Grip", c => c.String());
            AddColumn("dbo.Player", "PlayingStyle", c => c.String());
            AddColumn("dbo.Player", "Handness", c => c.String());
            AddColumn("dbo.Player", "Activity", c => c.Boolean(nullable: false));
            AddColumn("dbo.Player", "Gender", c => c.String());
            DropForeignKey("dbo.Player", "PlayingStyle_Id", "dbo.PlayingStyle");
            DropForeignKey("dbo.Player", "Handedness_Id", "dbo.Handedness");
            DropForeignKey("dbo.Player", "Grip_Id", "dbo.Grip");
            DropForeignKey("dbo.Player", "Gender_Id", "dbo.Gender");
            DropIndex("dbo.Player", new[] { "PlayingStyle_Id" });
            DropIndex("dbo.Player", new[] { "Handedness_Id" });
            DropIndex("dbo.Player", new[] { "Grip_Id" });
            DropIndex("dbo.Player", new[] { "Gender_Id" });
            DropColumn("dbo.Player", "PlayingStyle_Id");
            DropColumn("dbo.Player", "Handedness_Id");
            DropColumn("dbo.Player", "Grip_Id");
            DropColumn("dbo.Player", "Gender_Id");
            DropTable("dbo.PlayingStyle");
            DropTable("dbo.Handedness");
            DropTable("dbo.Grip");
            DropTable("dbo.Gender");
            CreateIndex("dbo.Tournament", "Player_Id");
            AddForeignKey("dbo.Tournament", "Player_Id", "dbo.Player", "Id");
        }
    }
}
