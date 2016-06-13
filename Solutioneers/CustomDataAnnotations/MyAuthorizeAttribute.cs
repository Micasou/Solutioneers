using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solutioneers.Models;

namespace Solutioneers.CustomDataAnnotations
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        var authorized = base.AuthorizeCore(httpContext);
        if (!authorized)
        {
            return false;
        }

        var rd = httpContext.Request.RequestContext.RouteData;

        var id = rd.Values["UserID"];
        var userName = httpContext.User.Identity.Name;
       //     Company Company = httpContext.GetType();// .GetLocalResourceObject()); //unit.SubmissionRepository.GetByID(id);
       //TODO C must grab the company owner username and compare it to the http request username

            return userName.Equals("");
    }
}
    
}