using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Common.Responses
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public ResponseType Type { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
