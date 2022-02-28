using FluentMigrator;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.Films
{
    [Migration(202202261210, "CreateFilmsTable")]
    [ExcludeFromCodeCoverage]
    public class CreateFilmsTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Table("Films").Exists())
            {
                Create.Table("Films")
                    .WithColumn("FilmId").AsInt32().PrimaryKey().NotNullable().Identity()
                    .WithColumn("Title").AsString().NotNullable()
                    .WithColumn("Description").AsString().NotNullable()
                    .WithColumn("Director").AsString().NotNullable()
                    .WithColumn("ReleaseDate").AsDate().NotNullable()
                    .WithColumn("Length").AsInt32().NotNullable();
            }
        }
    }
}
