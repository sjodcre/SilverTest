using System;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SilverTest.API.Controllers.ActionFilters
{
    public class ValidateAuthHeaderAttribute: ActionFilterAttribute
{
    private readonly ILogger<ValidateAuthHeaderAttribute> _logger;
    public ValidateAuthHeaderAttribute(ILogger<ValidateAuthHeaderAttribute> logger)
    {
        _logger = logger;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var httpContext = context.HttpContext;

        if (httpContext.Request.Headers.ContainsKey("Authorization"))
        {
            if (httpContext.Request.Headers["Authorization"] != ""){
                
                if (httpContext.Request.Headers["Authorization"] == "Bearer af24353tdsfw"){
                    return;
                }
            }
            
        }


        context.Result = new ContentResult
        {
            Content = "Authorization header either not present, no value, or incorrect value",
            ContentType = "application/json",
            StatusCode = 501
        };
    }
}
}