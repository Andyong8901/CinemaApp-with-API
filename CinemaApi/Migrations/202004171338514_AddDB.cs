namespace CinemaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDB : DbMigration
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
                "dbo.HallSeats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        ShowTime = c.DateTime(nullable: false),
                        SeatNumber = c.String(),
                        SeatPrice = c.Double(nullable: false),
                        Seatstatus = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .Index(t => t.HallId);
            
            CreateTable(
                "dbo.MovieCarts",
                c => new
                    {
                        MovieCartId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(),
                        Amount = c.Double(),
                        SeatId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieCartId)
                .ForeignKey("dbo.HallSeats", t => t.SeatId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SeatId)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.MovieDetails",
                c => new
                    {
                        MovieDetailId = c.Int(nullable: false, identity: true),
                        ShowTime = c.DateTime(nullable: false),
                        MovieId = c.Int(nullable: false),
                        HallId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieDetailId)
                .ForeignKey("dbo.Halls", t => t.HallId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.HallId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieNo = c.Int(nullable: false),
                        MovieName = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        IsShowing = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieDetails", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieDetails", "HallId", "dbo.Halls");
            DropForeignKey("dbo.MovieCarts", "UserId", "dbo.Users");
            DropForeignKey("dbo.MovieCarts", "SeatId", "dbo.HallSeats");
            DropForeignKey("dbo.HallSeats", "HallId", "dbo.Halls");
            DropIndex("dbo.MovieDetails", new[] { "HallId" });
            DropIndex("dbo.MovieDetails", new[] { "MovieId" });
            DropIndex("dbo.MovieCarts", new[] { "UserId" });
            DropIndex("dbo.MovieCarts", new[] { "SeatId" });
            DropIndex("dbo.HallSeats", new[] { "HallId" });
            DropTable("dbo.Movies");
            DropTable("dbo.MovieDetails");
            DropTable("dbo.Users");
            DropTable("dbo.MovieCarts");
            DropTable("dbo.HallSeats");
            DropTable("dbo.Halls");
        }
    }
}
