using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using TaskManage.DTOs;

namespace TaskManage.Common.Middleware
{
    internal sealed class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger,RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await ConvertExceptionAsync(context, ex, _logger);
            }
        }

        private static async Task ConvertExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            var errorResponse = new ErrorResponse() { ValidationErrors = new List<string>() };

            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    errorResponse.ValidationErrors.AddRange(validationException.ValdationErrors);
                    result = JsonConvert.SerializeObject(errorResponse);
                    logger.LogError(result);
                    break;

                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    errorResponse.ValidationErrors.Add(badRequestException.Message);
                    result = JsonConvert.SerializeObject(errorResponse);
                    logger.LogError(result);
                    break;

                case SqlException sqlException:
                    httpStatusCode= HttpStatusCode.BadRequest;
                    errorResponse.ValidationErrors.Add(sqlException.Message);
                    result = JsonConvert.SerializeObject(errorResponse);
                    logger.LogError(result);
                    break;

                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    errorResponse.ValidationErrors.Add(notFoundException.Message);
                    result = JsonConvert.SerializeObject(errorResponse);
                    logger.LogError(result);
                    break;

                case OperationCanceledException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    errorResponse.ValidationErrors.Add("Request was canceled");
                    result = JsonConvert.SerializeObject(errorResponse);
                    logger.LogError(result);
                    break;

                //case Azure.RequestFailedException azureException:
                //    httpStatusCode = HttpStatusCode.BadRequest;
                //    errorResponse.ValidationErrors.Add(azureException.Message);
                //    result = JsonConvert.SerializeObject(errorResponse);
                //    Log.Error(result);
                //    break;

                case Exception:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    errorResponse.ValidationErrors.Add("Something went wrong, please try again");
                    result = JsonConvert.SerializeObject(errorResponse);
                    logger.LogError(exception.Message);
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            await context.Response.WriteAsync(result);
        }
    }
}
