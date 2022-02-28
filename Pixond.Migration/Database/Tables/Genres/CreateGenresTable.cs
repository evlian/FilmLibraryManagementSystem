using FluentMigrator;
using System.Diagnostics.CodeAnalysis;

namespace Pixond.Migration.Database.Tables.Genres
{
    [Migration(202202261209, "CreateGenresTable")]
    [ExcludeFromCodeCoverage]
    public class CreateGenresTable : FluentMigrator.Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Table("Genres").Exists())
            {
                Create.Table("Genres")
                    .WithColumn("GenreId").AsInt32().PrimaryKey().NotNullable().Identity()
                    .WithColumn("Name").AsString().NotNullable();
            }
        }
    }
}
