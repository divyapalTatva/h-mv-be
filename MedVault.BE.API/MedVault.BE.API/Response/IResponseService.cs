using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedVault.BE.API.Response
{
    public interface IResponseService
    {
        IActionResult GetSuccessResponse<T>(HttpStatusCode httpStatusCode, T? data = default, params string[] messages);
    }
}
