using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Services;
using Oqtane.Shared;

namespace mdmontesinos.Module.Issue4812.Services
{
    public class Issue4812Service : ServiceBase, IIssue4812Service
    {
        public Issue4812Service(IHttpClientFactory http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Issue4812");

        public async Task<List<Models.Issue4812>> GetIssue4812sAsync(int ModuleId)
        {
            List<Models.Issue4812> Issue4812s = await GetJsonAsync<List<Models.Issue4812>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.Issue4812>().ToList());
            return Issue4812s.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Issue4812> GetIssue4812Async(int Issue4812Id, int ModuleId)
        {
            return await GetJsonAsync<Models.Issue4812>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Issue4812Id}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.Issue4812> AddIssue4812Async(Models.Issue4812 Issue4812)
        {
            return await PostJsonAsync<Models.Issue4812>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, Issue4812.ModuleId), Issue4812);
        }

        public async Task<Models.Issue4812> UpdateIssue4812Async(Models.Issue4812 Issue4812)
        {
            return await PutJsonAsync<Models.Issue4812>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Issue4812.Issue4812Id}", EntityNames.Module, Issue4812.ModuleId), Issue4812);
        }

        public async Task DeleteIssue4812Async(int Issue4812Id, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{Issue4812Id}", EntityNames.Module, ModuleId));
        }
    }
}
