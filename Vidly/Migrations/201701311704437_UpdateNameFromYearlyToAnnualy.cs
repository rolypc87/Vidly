namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameFromYearlyToAnnualy : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes SET Name = 'Annualy' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
