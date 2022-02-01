using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage (AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter {
    public string UserInRole { get; set; }
    public void OnAuthorization (AuthorizationFilterContext context) {
       // String token = context.HttpContext.Request.Cookies["Authorization"];
        var user = (User) context.HttpContext.Items["User"];

        if (user == null) {
            RedirectUnAuthUser (context);

        } else if (!String.IsNullOrEmpty (UserInRole)) {
            List<string> userRoles = user.UserRoles.Select (x => x.Role.Title).ToList ();
            if (!userRoles.Contains (UserInRole)) {
                RedirectUnAuthUser (context);
            }
        }
    }
    public void RedirectUnAuthUser (AuthorizationFilterContext context) {
        string name = (string) context.RouteData.Values["Controller"];
        if (!name.ToLower ().Contains ("api")) {
            context.HttpContext.Response.Redirect ("/user/login");
            return;
        }
        context.Result = new JsonResult (new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
    }
}