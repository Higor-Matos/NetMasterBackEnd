using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMaster.Domain.Results;

namespace NetMaster.Domain.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ToResult(
            this ControllerBase controller,
            ResultServiceModel value
        )
        {
            IActionResult result = controller.StatusCode(StatusCodes.Status500InternalServerError);
            if (value.SuccessResult != null)
            {
                return controller.Ok(value.SuccessResult.Result);
            }
            else if (value.ErrorResult != null)
            {
                return controller.BadRequest(value.ErrorResult.ErrorMessage);
            }
            return result;
        }
    }
}
