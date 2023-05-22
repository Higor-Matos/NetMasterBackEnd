// NetMaster.Controllers/BaseController.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results.Service;
using NetMaster.Presentation.Extensions;

namespace NetMaster.Presentation.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ToActionResult<T>(ServiceResultModel<T> result) where T : class
        {
            return this.CreateActionResultFromServiceResult(result);
        }

        protected IActionResult CheckIpIsNull(string ip)
        {
            return string.IsNullOrWhiteSpace(ip) ? BadRequest("IP address is required.") : Ok();
        }


        protected IActionResult? CheckComputerNameIsNull(string computerName)
        {
            return string.IsNullOrWhiteSpace(computerName) ? BadRequest("Computer name is required.") : (IActionResult?)null;
        }

    }
}
