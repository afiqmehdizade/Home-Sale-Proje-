using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProj.Areas.Admin.Controllers
{
    public class isAdmin:AuthorizeAttribute,IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["lgadmin"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Account/Login");
            }
        }
    }
}