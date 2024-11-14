using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace mdmontesinos.Module.Issue4812.Repository
{
    public class Issue4812Context : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.Issue4812> Issue4812 { get; set; }

        public Issue4812Context(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.Issue4812>().ToTable(ActiveDatabase.RewriteName("mdmontesinosIssue4812"));
        }
    }
}
