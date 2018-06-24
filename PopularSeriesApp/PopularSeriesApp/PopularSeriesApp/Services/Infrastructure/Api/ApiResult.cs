

namespace PopularSeriesApp.Services.Infrastructure.Api
{
    using System.Net;

    //Autor: Profº Willian S Rodriguez
    public static class ApiResult
    {
        public static ApiResult<T> Create<T>(T data)
            => new ApiResult<T>(data, true, HttpStatusCode.OK, null);

        internal static ApiResult<T> Create<T>(T data, bool status, HttpStatusCode statusCode, string message)
            => new ApiResult<T>(data, status, statusCode, message);
    }
    //Autor: Profº Willian S Rodriguez
    public class ApiResult<T>
    {
        public ApiResult(T data, bool success, HttpStatusCode statusCode, string message)
        {
            Data = data;
            Success = success;
            StatusCode = statusCode;
            Message = message;
        }

        public T Data { get; }
        public string Message { get; set; }

        public bool Success { get; }

        public HttpStatusCode StatusCode { get; }
    }
}
