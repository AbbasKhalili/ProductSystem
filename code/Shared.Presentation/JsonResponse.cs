using System.Dynamic;
using System.Text.Json;

namespace Shared.Presentation
{
    public class JsonResponse<T>
    {
        internal JsonResponse(bool status, string[]? errors = null)
        {
            Status = status;
            Errors = errors ?? [];
        }

        internal JsonResponse(bool status, T data, string[]? errors = null) : this(status, errors)
        {
            Data = data;
        }

        public bool Status { get; private set; }

        public string[] Errors { get; private set; }

        public dynamic Metadata { get; set; }

        public T Data { get; private set; }


        public static JsonResponse<T> Success() => new(true);

        public static JsonResponse<T> Success(T data) => new(true, data);

        public static JsonResponse<T> Failure(T error) => new(false, error);
        public static JsonResponse<T> Failure(string error) => new(false, [error]);

        public static JsonResponse<T> Failure(IEnumerable<string> errors) => new(false, [.. errors]);

        public JsonResponse<T> AssignMetaData(ExpandoObject metaData)
        {
            Metadata = metaData;
            return this;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}
