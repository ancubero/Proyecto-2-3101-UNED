using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Proyecto_2_3101.Extensions;

namespace Proyecto_2_3101.Filters;

public class ValidateSessionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);

        // Accessa la información de la sesión
        var usuario = filterContext.HttpContext.Session.GetUser();

        if (usuario != null) return;
        
        /*Salva TempData fuera del contexto del controlador para
            que cuando se haga el redirect este no se pierda
        */
        if (filterContext.Controller is Controller controller)
        {
            controller.TempData["sessionError"] = "La sesión ha expirado";
            controller.TempData.Keep("sessionError"); 
        }
        
        filterContext.Result = new RedirectToActionResult("Index", "Home", null);
    }
}