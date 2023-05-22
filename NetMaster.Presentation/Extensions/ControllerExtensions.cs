// NetMaster.Presentation/ControllerExtensions.cs
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results.Service;

namespace NetMaster.Presentation.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult CreateActionResultFromServiceResult<T>(this ControllerBase controller, ServiceResultModel<T> value)
            where T : class
        {
            if (value.SuccessResult != null)
            {
                return controller.Ok(value.SuccessResult.Result);
            }
            else
            {
                return value.ErrorResult != null
                    ? controller.BadRequest(value.ErrorResult.ErrorMessage)
                    : controller.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}