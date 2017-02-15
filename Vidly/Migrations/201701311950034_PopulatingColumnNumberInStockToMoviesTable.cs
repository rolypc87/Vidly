namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingColumnNumberInStockToMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("update Movies SET NumberInStock = 3 where Id=1");
            Sql("update Movies SET NumberInStock = 2 where Id=2");
            Sql("update Movies SET NumberInStock = 5 where Id=3");
            Sql("update Movies SET NumberInStock = 7 where Id=4");
            Sql("update Movies SET NumberInStock = 78 where Id=5");
        }
        
        public override void Down()
        {
        }
    }
}
