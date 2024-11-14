using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace mdmontesinos.Module.Issue4812.Migrations.EntityBuilders
{
    public class Issue4812EntityBuilder : AuditableBaseEntityBuilder<Issue4812EntityBuilder>
    {
        private const string _entityTableName = "mdmontesinosIssue4812";
        private readonly PrimaryKey<Issue4812EntityBuilder> _primaryKey = new("PK_mdmontesinosIssue4812", x => x.Issue4812Id);
        private readonly ForeignKey<Issue4812EntityBuilder> _moduleForeignKey = new("FK_mdmontesinosIssue4812_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public Issue4812EntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override Issue4812EntityBuilder BuildTable(ColumnsBuilder table)
        {
            Issue4812Id = AddAutoIncrementColumn(table,"Issue4812Id");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> Issue4812Id { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
