using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Proyecto_2_3101.Extensions;

namespace Proyecto_2_3101.Filters;

public class ValidateClientSessionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);

        // Accessa la información de la sesión
        var client = filterContext.HttpContext.Session.GetClient();

        if (client != null) return;
        
        /*Salva TempData fuera del contexto del controlador para
            que cuando se haga el redirect este no se pierda
        */
        if (filterContext.Controller is Controller controller)
        {
            controller.TempData["errorMessage"] = "No se ha seleccionado el cliente";
            controller.TempData.Keep("errorMessage"); 
        }
        
        filterContext.Result = new RedirectToActionResult("Search", "Client", null);
    }
}