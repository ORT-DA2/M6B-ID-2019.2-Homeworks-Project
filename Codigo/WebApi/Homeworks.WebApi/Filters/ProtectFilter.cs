using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Homeworks.BusinessLogic.Interface;
using Homeworks.Domain;
using Homeworks.BusinessLogic;

namespace Homeworks.WebApi.Filters
{
public class ProtectFilter : Attribute, IActionFilter
{
    private readonly string _role;
    private ISession<UserSession> userSessions;
    public ProtectFilter(string role) 
    {
        _role = role;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        string token = context.HttpContext.Request.Headers["Authorization"];
        if (token == null)
        {
            context.Result = new ContentResult()
            {
                StatusCode = 400,
                Content = "Token is required",
            };
            return;
        }
        userSessions = GetSessions(context);
        Guid tokenGuid = Guid.Parse(token);
        if(!userSessions.isLogued(tokenGuid))
        {
            context.Result = new ContentResult()
            {
                StatusCode = 400,
                Content = "Invalid Token",
            };
            return;
        }
        if (!userSessions.IsAdmin(tokenGuid))
        {
            context.Result = new ContentResult()
            {
                StatusCode = 400,
                Content = "The user isen't Admin",
            };
            return;
        }
    }

    private static ISession<UserSession> GetSessions(ActionExecutingContext context)
        {
            return (ISession<UserSession>)context.HttpContext.RequestServices.GetService(typeof(ISession<UserSession>));
        }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // do something after the action executes
    }
}
}