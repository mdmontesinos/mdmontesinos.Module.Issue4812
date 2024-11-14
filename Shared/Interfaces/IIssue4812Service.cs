using System.Collections.Generic;
using System.Threading.Tasks;

namespace mdmontesinos.Module.Issue4812.Services
{
    public interface IIssue4812Service 
    {
        Task<List<Models.Issue4812>> GetIssue4812sAsync(int ModuleId);

        Task<Models.Issue4812> GetIssue4812Async(int Issue4812Id, int ModuleId);

        Task<Models.Issue4812> AddIssue4812Async(Models.Issue4812 Issue4812);

        Task<Models.Issue4812> UpdateIssue4812Async(Models.Issue4812 Issue4812);

        Task DeleteIssue4812Async(int Issue4812Id, int ModuleId);
    }
}
