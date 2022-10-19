using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Middleware;

public class Middleware
{
    private readonly RequestDelegate _next;
    public Middleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        async Task AddProblemDetailsToResponseAsync(ProblemDetails problemDetails)
        {
            var response = context.Response;
            response.StatusCode = (int)problemDetails.Status!;
            await response.WriteAsJsonAsync(problemDetails);
        }
        try
        {
            await _next.Invoke(context);
        }
        catch(Exception ex)
        {
            //If ProblemDetails is returned instead of throwing error, -
            //This exception should only be of type Internal Server Error,
            //because all other exception should be handleded through returning problem details
            ProblemDetails problem = new ProblemDetails
            {
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = "Internal Server Error",
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = ex.Message
            };
            //TODO: AddLogging
            await AddProblemDetailsToResponseAsync(problem);
        }
    }
     

}
