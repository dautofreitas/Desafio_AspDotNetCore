using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Filters
{
    public class ValidationFilter : IAuthorizationFilter
    {

       
        public void OnActionExecuting(ActionExecutingContext context)
        {
          
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
