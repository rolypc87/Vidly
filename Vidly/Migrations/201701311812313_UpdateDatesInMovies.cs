namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatesInMovies : DbMigration
    {
        public override void Up()
        {
            Sql("update Movies SET ReleaseDate = '05/26/1987', DateAdded='05/26/1995' where Id=1");
            Sql("update Movies SET ReleaseDate = '10/22/1955', DateAdded='12/30/1960' where Id=2");
            Sql("update Movies SET ReleaseDate = '08/25/1978', DateAdded='07/24/1981' where Id=3");
            Sql("update Movies SET ReleaseDate = '03/15/1945', DateAdded='11/13/1953' where Id=4");
            Sql("update Movies SET ReleaseDate = '12/24/1996', DateAdded='02/14/2000' where Id=5");
        }
        
        public override void Down()
        {
        }
    }
}
