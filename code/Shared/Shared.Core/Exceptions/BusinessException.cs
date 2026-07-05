using System.Net;

namespace Shared.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public int Code { get; }
        public HttpStatusCode StatusCode { get; }
        public string ExceptionMessage { get; }

        public BusinessException(int code, string message = "", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            Code = code;
            ExceptionMessage = message;
            StatusCode = statusCode;
        }

        public BusinessException(string message = "", HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            ExceptionMessage = message;
            StatusCode = statusCode;
        }
    }
}
