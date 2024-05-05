using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using TechECommerce.Business.Utilities.DTOs.Common;
using TechECommerce.Business.Utilities.Exceptions;

namespace TechECommerce.API.Extentions;

public static class AddExceptionHandlerExtension
{
    public static IApplicationBuilder AddExceptionHandlerService(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(error =>
        {
            error.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                int statusCode = (int)HttpStatusCode.InternalServerError;
                string message = "Internal Server Error";

                if (contextFeature.Error is IBaseException)
                {
                    var exception = (IBaseException)contextFeature.Error;
                    statusCode = exception.StatusCode;
                    message = exception.Message;
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(new ResponseDto(statusCode, message));
                await context.Response.CompleteAsync();
            });
        });
        return app;
    }
}
