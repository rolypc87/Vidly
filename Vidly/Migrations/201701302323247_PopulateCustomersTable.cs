namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomersTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES('John Smith',0,1)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES('Mary Williams',1,2)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES('Dan Henderson',0,3)");
            Sql("INSERT INTO Customers (Name, IsSubscribedToNewsletter, MembershipTypeId) VALUES('Anderson Silva',1,4)");
        }
        
        public override void Down()
        {
        }
    }
}
