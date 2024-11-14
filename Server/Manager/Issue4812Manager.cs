using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Interfaces;
using Oqtane.Enums;
using Oqtane.Repository;
using mdmontesinos.Module.Issue4812.Repository;
using System.Threading.Tasks;

namespace mdmontesinos.Module.Issue4812.Manager
{
    public class Issue4812Manager : MigratableModuleBase, IInstallable, IPortable, ISearchable
    {
        private readonly IIssue4812Repository _Issue4812Repository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public Issue4812Manager(IIssue4812Repository Issue4812Repository, IDBContextDependencies DBContextDependencies)
        {
            _Issue4812Repository = Issue4812Repository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new Issue4812Context(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new Issue4812Context(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.Issue4812> Issue4812s = _Issue4812Repository.GetIssue4812s(module.ModuleId).ToList();
            if (Issue4812s != null)
            {
                content = JsonSerializer.Serialize(Issue4812s);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.Issue4812> Issue4812s = null;
            if (!string.IsNullOrEmpty(content))
            {
                Issue4812s = JsonSerializer.Deserialize<List<Models.Issue4812>>(content);
            }
            if (Issue4812s != null)
            {
                foreach(var Issue4812 in Issue4812s)
                {
                    _Issue4812Repository.AddIssue4812(new Models.Issue4812 { ModuleId = module.ModuleId, Name = Issue4812.Name });
                }
            }
        }

        public Task<List<SearchContent>> GetSearchContentsAsync(PageModule pageModule, DateTime lastIndexedOn)
        {
           var searchContentList = new List<SearchContent>();

           foreach (var Issue4812 in _Issue4812Repository.GetIssue4812s(pageModule.ModuleId))
           {
               if (Issue4812.ModifiedOn >= lastIndexedOn)
               {
                   searchContentList.Add(new SearchContent
                   {
                       EntityName = "mdmontesinosIssue4812",
                       EntityId = Issue4812.Issue4812Id.ToString(),
                       Title = Issue4812.Name,
                       Body = Issue4812.Name,
                       ContentModifiedBy = Issue4812.ModifiedBy,
                       ContentModifiedOn = Issue4812.ModifiedOn
                   });
               }
           }

           return Task.FromResult(searchContentList);
        }
    }
}
