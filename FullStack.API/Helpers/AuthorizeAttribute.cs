
using FullStack.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = (UserModel)context.HttpContext.Items["User"];
        var advert = (AdvertModel)context.HttpContext.Items["Advert"];
          
    }
}
