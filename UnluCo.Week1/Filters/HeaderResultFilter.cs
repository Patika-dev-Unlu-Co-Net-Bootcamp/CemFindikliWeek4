using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UnluCo.Week1.Filters
{
    public class HeaderResultFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string date = DateTime.Now.ToString();
            context.HttpContext.Response.Headers.Add("Response",date);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string date = DateTime.Now.ToString();
            context.HttpContext.Response.Headers.Add("Request",date);
        }
    }
}
