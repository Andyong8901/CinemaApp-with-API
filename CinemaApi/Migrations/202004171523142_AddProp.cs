namespace CinemaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieCarts", "SeatNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieCarts", "SeatNo");
        }
    }
}
