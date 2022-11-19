using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;



namespace PROJECT_DSWI.Permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
       /* public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

            base.OnActionExecuting(filterContext);
        }*/
    }
}
