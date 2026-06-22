using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Common.Responses
{
    public static class ResponseHelper
    {
        public static ApiResponse<T> Success<T>(T data, string message = "")
        {
            return new ApiResponse<T>
            {
                StatusCode = ApiStatusCodes.Ok,
                Type = ResponseType.Success,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Created<T>(T data, string message = "")
        {
            return new ApiResponse<T>
            {
                StatusCode = ApiStatusCodes.Created,
                Type = ResponseType.Created,
                Message = message,
                Data = data
            };
        }

        public static ApiResponse<T> Failed<T>(string message = "")
        {
            return new ApiResponse<T>
            {
                StatusCode = ApiStatusCodes.BadRequest,
                Type = ResponseType.Failed,
                Message = message
            };
        }

        public static ApiResponse<T> NotFound<T>(string message = "")
        {
            return new ApiResponse<T>
            {
                StatusCode = ApiStatusCodes.NotFound,
                Type = ResponseType.NotFound,
                Message = message
            };
        }
    }
}
