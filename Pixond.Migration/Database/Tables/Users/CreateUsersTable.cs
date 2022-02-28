using FluentMigrator;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.Users
{
    [Migration(202202261559, "CreateUsersTable")]
    [ExcludeFromCodeCoverage]
    public class CreateUsersTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Table("Users").Exists()) 
            {
                Create.Table("Users")
                    .WithColumn("UserId").AsInt32().PrimaryKey().Identity().NotNullable()
                    .WithColumn("Name").AsString().NotNullable()
                    .WithColumn("Username").AsString().NotNullable()
                    .WithColumn("Password").AsString().NotNullable();
            }
        }
    }
}
