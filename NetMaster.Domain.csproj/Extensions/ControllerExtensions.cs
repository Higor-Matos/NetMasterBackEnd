using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Domain.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ToResult<T>(this ControllerBase controller, ServiceResultModel<T> value)
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
