using MedVault.BE.Common.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedVault.BE.API.Response
{
    public class ResponseService : IResponseService
    {
        public IActionResult GetSuccessResponse<T>(HttpStatusCode httpStatusCode, T? data = default, params string[] messages)
        {
            var response = new SuccessApiResponse<T?>(
                (int)httpStatusCode,
                messages?.Length > 0 ? [.. messages] : [],
                data
             );

            return new ObjectResult(response)
            {
                StatusCode = (int)httpStatusCode
            };
        }
    }
}
