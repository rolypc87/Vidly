namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, GenreId) VALUES('Hangover',05/26/1987,05/26/1995,1)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, GenreId) VALUES('Die Hard',10/22/1955,12/30/1960,2)");
            Sql("INSERT INTO Movies (Name, ReleaseDate, DateAdded, GenreId) VALUES('The Terminator',08/25/1978,07/24/1981,3)");
            Sql("INSERT INTO Movies (Name,  ReleaseDate, DateAdded, GenreId) VALUES('Toy Story',03/15/1945,11/13/1953,4)");
            Sql("INSERT INTO Movies (Name,  ReleaseDate, DateAdded, GenreId) VALUES('Titanic',12/24/1996,02/14/2000,4)");
        }
        
        public override void Down()
        {
        }
    }
}
