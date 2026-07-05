namespace Shared.Presentation
{
    public class JsonResponsePagination<T> : JsonResponse<T>
    {
        public new JsonResponsePaginationMetaData Metadata { get; set; }

        private JsonResponsePagination(bool status, string[]? errors = null) : base(status, errors)
        {
            this.Metadata = new JsonResponsePaginationMetaData(0, 0, 0);
        }

        private JsonResponsePagination(bool status, T data, int totalCount, int totalPages, int currentPage, string[] errors) : base(status, data, errors)
        {
            this.Metadata = new JsonResponsePaginationMetaData(totalCount, totalPages, currentPage);
        }


        public class JsonResponsePaginationMetaData(int totalCount, int totalPages, int currentPage)
        {
            public int TotalCount { get; private set; } = totalCount;
            public int TotalPages { get; private set; } = totalPages;
            public int CurrentPage { get; private set; } = currentPage;
            public bool HasNext => CurrentPage < (TotalPages - 1) && TotalCount > 0;
            public bool HasPrevious => CurrentPage > 0;
        }

        public new static JsonResponsePagination<T> Success() =>
            new JsonResponsePagination<T>(true);

        public static JsonResponsePagination<T> Success(T data, int totalCount = 0, int totalPages = 0, int currentPage = 0) =>
            new JsonResponsePagination<T>(true, data, totalCount, totalPages, currentPage, new string[] { });

        public new static JsonResponsePagination<T> Failure(string errors) =>
            new JsonResponsePagination<T>(false, new[] { errors });

        public new static JsonResponsePagination<T> Failure(IEnumerable<string> errors) =>
            new JsonResponsePagination<T>(false, errors.ToArray());
    }

}
