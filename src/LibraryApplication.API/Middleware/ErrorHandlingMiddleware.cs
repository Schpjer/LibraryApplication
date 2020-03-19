using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;


namespace BookRegister.API.Infastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
       
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //Simple error handling middleware that will handle exceptions in the code and respond with a HttpStatusCode
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            if (ex is ArgumentNullException) code = HttpStatusCode.NotFound;
            else if (ex is DbUpdateException) code = HttpStatusCode.Conflict;
            var result = JsonConvert.SerializeObject(new { error = code });
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}