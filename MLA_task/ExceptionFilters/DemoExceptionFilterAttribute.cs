using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using MLA_task.BLL.Interface.Exceptions;
using Error = MLA_task.BLL.Interface.Exceptions.DemoServiceException.ErrorType;

namespace MLA_task.ExceptionFilters
{
    public class DemoExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //Add logger here ?

        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception as DemoServiceException;

            if (exception != null)
            {
                switch (exception.Error)
                {
                    case Error.WrongId:                        
                        context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                        var argumentsWrongId = context.ActionContext.ActionArguments;
                        context.Response.Content = new StringContent($"Wrong id {argumentsWrongId["id"]}");
                        break;
                    case Error.WrongName:
                        context.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);                        
                        context.Response.Content = new StringContent($"Wrong name");
                        break;
                    default:
                        context.Request.CreateResponse(HttpStatusCode.InternalServerError);
                        break;
                }
            }
            else
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}