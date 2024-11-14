using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using mdmontesinos.Module.Issue4812.Repository;
using Oqtane.Controllers;
using System.Net;

namespace mdmontesinos.Module.Issue4812.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class Issue4812Controller : ModuleControllerBase
    {
        private readonly IIssue4812Repository _Issue4812Repository;

        public Issue4812Controller(IIssue4812Repository Issue4812Repository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _Issue4812Repository = Issue4812Repository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Issue4812> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _Issue4812Repository.GetIssue4812s(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Issue4812 Get(int id)
        {
            Models.Issue4812 Issue4812 = _Issue4812Repository.GetIssue4812(id);
            if (Issue4812 != null && IsAuthorizedEntityId(EntityNames.Module, Issue4812.ModuleId))
            {
                return Issue4812;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Get Attempt {Issue4812Id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Issue4812 Post([FromBody] Models.Issue4812 Issue4812)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, Issue4812.ModuleId))
            {
                Issue4812 = _Issue4812Repository.AddIssue4812(Issue4812);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Issue4812 Added {Issue4812}", Issue4812);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Post Attempt {Issue4812}", Issue4812);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Issue4812 = null;
            }
            return Issue4812;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Issue4812 Put(int id, [FromBody] Models.Issue4812 Issue4812)
        {
            if (ModelState.IsValid && Issue4812.Issue4812Id == id && IsAuthorizedEntityId(EntityNames.Module, Issue4812.ModuleId) && _Issue4812Repository.GetIssue4812(Issue4812.Issue4812Id, false) != null)
            {
                Issue4812 = _Issue4812Repository.UpdateIssue4812(Issue4812);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Issue4812 Updated {Issue4812}", Issue4812);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Put Attempt {Issue4812}", Issue4812);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Issue4812 = null;
            }
            return Issue4812;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Issue4812 Issue4812 = _Issue4812Repository.GetIssue4812(id);
            if (Issue4812 != null && IsAuthorizedEntityId(EntityNames.Module, Issue4812.ModuleId))
            {
                _Issue4812Repository.DeleteIssue4812(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Issue4812 Deleted {Issue4812Id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Issue4812 Delete Attempt {Issue4812Id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
