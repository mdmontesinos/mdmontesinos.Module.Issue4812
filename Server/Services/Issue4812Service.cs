using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Oqtane.Models;
using Oqtane.Security;
using Oqtane.Shared;
using mdmontesinos.Module.Issue4812.Repository;

namespace mdmontesinos.Module.Issue4812.Services
{
    public class ServerIssue4812Service : IIssue4812Service
    {
        private readonly IIssue4812Repository _Issue4812Repository;
        private readonly IUserPermissions _userPermissions;
        private readonly ILogManager _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly Alias _alias;

        public ServerIssue4812Service(IIssue4812Repository Issue4812Repository, IUserPermissions userPermissions, ITenantManager tenantManager, ILogManager logger, IHttpContextAccessor accessor)
        {
            _Issue4812Repository = Issue4812Repository;
            _userPermissions = userPermissions;
            _logger = logger;
            _accessor = accessor;
            _alias = tenantManager.GetAlias();
        }

        public Task<List<Models.Issue4812>> GetIssue4812sAsync(int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_Issue4812Repository.GetIssue4812s(ModuleId).ToList());
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Get Attempt {ModuleId}", ModuleId);
                return null;
            }
        }

        public Task<Models.Issue4812> GetIssue4812Async(int Issue4812Id, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.View))
            {
                return Task.FromResult(_Issue4812Repository.GetIssue4812(Issue4812Id));
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Get Attempt {Issue4812Id} {ModuleId}", Issue4812Id, ModuleId);
                return null;
            }
        }

        public Task<Models.Issue4812> AddIssue4812Async(Models.Issue4812 Issue4812)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, Issue4812.ModuleId, PermissionNames.Edit))
            {
                Issue4812 = _Issue4812Repository.AddIssue4812(Issue4812);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Issue4812 Added {Issue4812}", Issue4812);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Add Attempt {Issue4812}", Issue4812);
                Issue4812 = null;
            }
            return Task.FromResult(Issue4812);
        }

        public Task<Models.Issue4812> UpdateIssue4812Async(Models.Issue4812 Issue4812)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, Issue4812.ModuleId, PermissionNames.Edit))
            {
                Issue4812 = _Issue4812Repository.UpdateIssue4812(Issue4812);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Issue4812 Updated {Issue4812}", Issue4812);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Update Attempt {Issue4812}", Issue4812);
                Issue4812 = null;
            }
            return Task.FromResult(Issue4812);
        }

        public Task DeleteIssue4812Async(int Issue4812Id, int ModuleId)
        {
            if (_userPermissions.IsAuthorized(_accessor.HttpContext.User, _alias.SiteId, EntityNames.Module, ModuleId, PermissionNames.Edit))
            {
                _Issue4812Repository.DeleteIssue4812(Issue4812Id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Issue4812 Deleted {Issue4812Id}", Issue4812Id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Delete Attempt {Issue4812Id} {ModuleId}", Issue4812Id, ModuleId);
            }
            return Task.CompletedTask;
        }
    }
}
