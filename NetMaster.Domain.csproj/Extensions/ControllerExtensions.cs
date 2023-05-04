using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Models.Results;

namespace NetMaster.Domain.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ToResult<T>(this ControllerBase controller, ServiceResultModel<T> value)
            where T : class
        {
            return value.SuccessResult != null
                ? controller.Ok(value.SuccessResult.Result)
                : value.ErrorResult != null
                    ? controller.BadRequest(value.ErrorResult.ErrorMessage)
                    : controller.StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
