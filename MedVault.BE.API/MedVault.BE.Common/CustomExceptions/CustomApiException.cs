using MedVault.BE.Common.Constants;
using System.Net;

namespace MedVault.BE.Common.CustomExceptions
{
    public abstract class CustomApiException : Exception
    {
        public int StatusCode { get; }

        public IReadOnlyList<string> Messages { get; }

        public IReadOnlyDictionary<string, object>? Metadata { get; }

        protected CustomApiException(int statusCode, string message, IDictionary<string, object>? metadata = null)
            : base(message)
        {
            StatusCode = statusCode;
            Messages = new[] { message };
            Metadata = metadata is not null
                ? new Dictionary<string, object>(metadata)
                : null;
        }

        protected CustomApiException(int statusCode, IEnumerable<string> messages, IDictionary<string, object>? metadata = null)
            : base(messages?.FirstOrDefault() ?? ExceptionMessage.CUSTOM_API_EXCEPTION_MESSAGE)
        {
            StatusCode = statusCode;
            Messages = messages?.ToList() ?? new List<string> { ExceptionMessage.CUSTOM_API_EXCEPTION_MESSAGE };
            Metadata = metadata is not null
                ? new Dictionary<string, object>(metadata)
                : null;
        }
    }

    public class DataAlreadyExistsException : CustomApiException
    {
        public DataAlreadyExistsException(string message, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.Conflict, message, metadata) { }

        public DataAlreadyExistsException(IEnumerable<string> messages, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.Conflict, messages, metadata) { }
    }

    public class ForbiddenException : CustomApiException
    {
        public ForbiddenException(string message, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.Forbidden, message, metadata) { }

        public ForbiddenException(IEnumerable<string> messages, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.Forbidden, messages, metadata) { }
    }

    public class BadRequestException : CustomApiException
    {
        public BadRequestException(string message, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.BadRequest, message, metadata) { }

        public BadRequestException(IEnumerable<string> messages, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.BadRequest, messages, metadata) { }
    }

    public class EntityNullException : CustomApiException
    {
        public EntityNullException(string message, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.NotFound, message, metadata) { }

        public EntityNullException(IEnumerable<string> messages, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.NotFound, messages, metadata) { }
    }

    public class ValidationException : CustomApiException
    {
        public ValidationException(string message, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.BadRequest, message, metadata) { }

        public ValidationException(IEnumerable<string> messages, IDictionary<string, object>? metadata = null)
            : base((int)HttpStatusCode.BadRequest, messages, metadata) { }
    }
}