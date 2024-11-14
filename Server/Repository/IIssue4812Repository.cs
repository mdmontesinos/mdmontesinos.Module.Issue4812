using System.Collections.Generic;
using System.Threading.Tasks;

namespace mdmontesinos.Module.Issue4812.Repository
{
    public interface IIssue4812Repository
    {
        IEnumerable<Models.Issue4812> GetIssue4812s(int ModuleId);
        Models.Issue4812 GetIssue4812(int Issue4812Id);
        Models.Issue4812 GetIssue4812(int Issue4812Id, bool tracking);
        Models.Issue4812 AddIssue4812(Models.Issue4812 Issue4812);
        Models.Issue4812 UpdateIssue4812(Models.Issue4812 Issue4812);
        void DeleteIssue4812(int Issue4812Id);
    }
}
