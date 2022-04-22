using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace RestApiSample.Extensions
{
  /// <summary>
  /// This class contains logic for handeling unhandeled extensions at global level.
  /// </summary>
  public static class GlobalExceptionHandler
  {
    public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
    {
      app.UseExceptionHandler(appError =>
      {
        appError.Run(async context =>
        {
          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          context.Response.ContentType = "application/json";
          var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
          if (contextFeature != null)
          {
            // Todo: Use FileLogger to write exception stack trace.

            await context.Response.WriteAsync(new ErrorResponse()
            {
              StatusCode = context.Response.StatusCode,
              Message = "Internal Server Error. Check server log for details."
            }.ToString());
          }
        });
      });
    }
  }
}
