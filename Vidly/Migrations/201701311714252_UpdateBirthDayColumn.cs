namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDayColumn : DbMigration
    {
        public override void Up()
        {
            Sql("update Customers SET BirthDay = '04-30-1987' where Id=1");
            Sql("update Customers SET BirthDay = '03-24-1982' where Id=2");
            Sql("update Customers SET BirthDay = '10-07-1957' where Id=3");
        }

        public override void Down()
        {
        }
    }
}
