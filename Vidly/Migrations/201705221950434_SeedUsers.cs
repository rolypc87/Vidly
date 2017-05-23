namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
		  Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ff610c99-3ed3-4627-9b2d-fb8c12277dd4', N'admin@vidly.com', 0, N'ANpWYD0MH+L7E4FSQvRZ1ITYWD6T31ngKhQyKCsRFpeUjj+M5XfNY+fHiyw4E+HoQw==', N'93fec834-4aba-4322-b487-59662ac6e125', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8410ce13-570b-4cf4-ba8e-9880577b8b44', N'gest@vidly.com', 0, N'ADpmW7yUdmZslv+hhPo9DMdr8QFFzhB7rxp15xgMKRpYEHgPboJZRVsPJqy0bLZ+6A==', N'bf4d2018-0f7a-49ae-935c-e3edcfabe008', NULL, 0, 0, NULL, 1, 0, N'gest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bc14fbf5-8c47-4e1e-a4d8-559256310cd7', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ff610c99-3ed3-4627-9b2d-fb8c12277dd4', N'bc14fbf5-8c47-4e1e-a4d8-559256310cd7')
");
        }
        
        public override void Down()
        {
        }
    }
}
