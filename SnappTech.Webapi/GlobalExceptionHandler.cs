using Azure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SnappTech.Application.Dto.Base;
using SnappTech.Domain.Common;
using System.Diagnostics;
using System.Net;

namespace snap_tech_project
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

            logger.LogError(
                exception,
                "Could not process a request on machine {MachineName}. TraceId: {TraceId}",
                Environment.MachineName,
                traceId
            );

            BaseResponse resposne;
            if (exception is AppException || exception is DomainException)
            {
                resposne = new BaseResponse()
                {
                    StatusCode = 400,
                    Message = exception.Message
                };
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else
            {
                resposne = new BaseResponse()
                {
                    StatusCode = 550,
                    Message = "Internal server error"
                };
            }
            
            await httpContext.Response.WriteAsJsonAsync(resposne, cancellationToken);
            return true;
        }
    }
}
