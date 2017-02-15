namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDayColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDay");
        }
    }
}
