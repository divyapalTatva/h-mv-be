using MedVault.BE.Common.CustomExceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace MedVault.BE.API.CustomExceptions
{
    public class InvalidModelStateException : CustomApiException
    {
        public InvalidModelStateException(string message, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.BadRequest, message, metadata) { }

        public InvalidModelStateException(IEnumerable<string> messages, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.BadRequest, messages, metadata) { }

        public InvalidModelStateException(ModelStateDictionary modelState, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.BadRequest, ExtractMessages(modelState), metadata) { }

        private static IEnumerable<string> ExtractMessages(ModelStateDictionary modelState)
        {
            return modelState.Values
                             .SelectMany(v => v.Errors)
                             .Select(e => e.ErrorMessage)
                             .ToList();
        }
    }
}
