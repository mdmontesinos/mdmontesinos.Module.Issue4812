using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using mdmontesinos.Module.Issue4812.Migrations.EntityBuilders;
using mdmontesinos.Module.Issue4812.Repository;

namespace mdmontesinos.Module.Issue4812.Migrations
{
    [DbContext(typeof(Issue4812Context))]
    [Migration("mdmontesinos.Module.Issue4812.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new Issue4812EntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new Issue4812EntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
