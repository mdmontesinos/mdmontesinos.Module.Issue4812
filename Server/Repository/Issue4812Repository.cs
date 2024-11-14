using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

namespace mdmontesinos.Module.Issue4812.Repository
{
    public class Issue4812Repository : IIssue4812Repository, ITransientService
    {
        private readonly IDbContextFactory<Issue4812Context> _factory;

        public Issue4812Repository(IDbContextFactory<Issue4812Context> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.Issue4812> GetIssue4812s(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return db.Issue4812.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public Models.Issue4812 GetIssue4812(int Issue4812Id)
        {
            return GetIssue4812(Issue4812Id, true);
        }

        public Models.Issue4812 GetIssue4812(int Issue4812Id, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.Issue4812.Find(Issue4812Id);
            }
            else
            {
                return db.Issue4812.AsNoTracking().FirstOrDefault(item => item.Issue4812Id == Issue4812Id);
            }
        }

        public Models.Issue4812 AddIssue4812(Models.Issue4812 Issue4812)
        {
            using var db = _factory.CreateDbContext();
            db.Issue4812.Add(Issue4812);
            db.SaveChanges();
            return Issue4812;
        }

        public Models.Issue4812 UpdateIssue4812(Models.Issue4812 Issue4812)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(Issue4812).State = EntityState.Modified;
            db.SaveChanges();
            return Issue4812;
        }

        public void DeleteIssue4812(int Issue4812Id)
        {
            using var db = _factory.CreateDbContext();
            Models.Issue4812 Issue4812 = db.Issue4812.Find(Issue4812Id);
            db.Issue4812.Remove(Issue4812);
            db.SaveChanges();
        }
    }
}
