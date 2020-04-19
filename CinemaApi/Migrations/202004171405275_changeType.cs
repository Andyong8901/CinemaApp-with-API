namespace CinemaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovieCarts", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieCarts", "Amount", c => c.Double());
        }
    }
}
