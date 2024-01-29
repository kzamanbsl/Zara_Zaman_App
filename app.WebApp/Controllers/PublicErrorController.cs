using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace app.WebApp.Controllers
{
    public class PublicErrorController : Controller
    {
        [Route("PublicError")]
        [AllowAnonymous]
        public IActionResult PublicError()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = exceptionDetails.Path;
            var errorMessage= exceptionDetails.Error.Message;
            if (errorMessage.StartsWith("Sorry"))
            {
                ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            }
            else
            {
                ViewBag.ExceptionMessage =
                    "An error occurred while processing your request. Please contact with support team!";
            }
            
            //ViewBag.ExceptionStackTrace = exceptionDetails.Error.StackTrace;
            return View();
        }
    }
}
