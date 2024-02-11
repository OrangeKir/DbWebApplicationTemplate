using DbWebApplicationTemplate.Infrastructure;
using FluentMigrator;

namespace DbWebApplicationTemplate.DataAccess.Migrations;

[Migration(1)]
public class InitMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.Table(PgTables.Record)
            .WithColumn("id").AsGuid().PrimaryKey().WithDefault(SystemMethods.NewGuid)
            .WithColumn("data").AsString().NotNullable();
    }
}