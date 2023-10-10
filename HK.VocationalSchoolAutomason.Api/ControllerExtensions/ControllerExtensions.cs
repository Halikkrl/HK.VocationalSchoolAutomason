using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using Microsoft.AspNetCore.Mvc;

namespace HK.VocationalSchoolAutomason.Api.ControllerExtensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectToAction<T> (this Controller controller, IResponse<T> response, string actionName)
        {
            if(response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if(response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return controller.RedirectToAction(actionName);
        }

        public static IActionResult ResponseApi<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            else if (response.ResponseType == ResponseType.ValidationError)
            {
                var validationErrors = response.ValidationErrors.Select(error => new
                {
                    error.PropertyName,
                    error.ErrorMessage
                }).ToList();

                return controller.BadRequest(validationErrors);
            }
            else if (response.ResponseType == ResponseType.Success)
            {
                return controller.Ok(response.Data);
            }
            else
            {
                return controller.StatusCode(500, "Internal Server Error");
            }
        }

        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionName)
        {
            if(response.ResponseType == ResponseType.NotFound)
            { return controller.NotFound(); }
            return controller.RedirectToAction(actionName);
        }

    }
}
