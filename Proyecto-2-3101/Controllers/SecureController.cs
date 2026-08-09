using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Proyecto_2_3101.Extensions;

namespace Proyecto_2_3101.Controllers;

public class SecureController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);
        
        var usuario = HttpContext.Session.GetUser();

        if (usuario != null) return;
        
        TempData["sessionError"] = "La session ha expirado";
        filterContext.Result = new RedirectToActionResult("Index", "Home", null);
    }
}