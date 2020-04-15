namespace CinemaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        HallId = c.Int(nullable: false, identity: true),
                        HallNo = c.Int(nullable: false),
                        SeatRow = c.Int(nullable: false),
                        SeatColumn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HallId);
            
            CreateTable(
                "dbo.MovieDetails",
                c => new
                    {
                        MovieDetailId = c.Int(nullable: false, identity: true),
                        ShowTime = c.DateTime(nullable: false),
                        MovieId = c.Int(nullable: false),
                        HallNo = c.Int(nullable: false),
                        Hall_HallId = c.Int(),
                    })
                .PrimaryKey(t => t.MovieDetailId)
                .ForeignKey("dbo.Halls", t => t.Hall_HallId)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.Hall_HallId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        IsShowing = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
            CreateTable(
                "dbo.MovieHallSeats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        ShowTime = c.DateTime(nullable: false),
                        SeatNumber = c.String(),
                        Seatstatus = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.HallId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieHallSeats", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieHallSeats", "HallId", "dbo.Halls");
            DropForeignKey("dbo.MovieDetails", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieDetails", "Hall_HallId", "dbo.Halls");
            DropIndex("dbo.MovieHallSeats", new[] { "MovieId" });
            DropIndex("dbo.MovieHallSeats", new[] { "HallId" });
            DropIndex("dbo.MovieDetails", new[] { "Hall_HallId" });
            DropIndex("dbo.MovieDetails", new[] { "MovieId" });
            DropTable("dbo.Users");
            DropTable("dbo.MovieHallSeats");
            DropTable("dbo.Movies");
            DropTable("dbo.MovieDetails");
            DropTable("dbo.Halls");
        }
    }
}
