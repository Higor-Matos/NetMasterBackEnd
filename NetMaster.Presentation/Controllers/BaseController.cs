// NetMaster.Controllers/BaseController.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Extensions;
using NetMaster.Domain.Models.Results;

public abstract class BaseController : ControllerBase
{
    protected IActionResult ToActionResult<T>(ServiceResultModel<T> result) where T : class
    {
        return this.ToResult(result);
    }
}
