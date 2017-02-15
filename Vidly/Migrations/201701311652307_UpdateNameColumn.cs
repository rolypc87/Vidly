namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameColumn : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes SET Name = 'Pay as You Go' where Id=1");
            Sql("update MembershipTypes SET Name = 'Monthly' where Id=2");
            Sql("update MembershipTypes SET Name = 'Trimestral' where Id=3");
            Sql("update MembershipTypes SET Name = 'Yearly' where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
