using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Common.Responses
{
    public static class ApiStatusCodes
    {
        public const int Ok = 200;
        public const int Created = 201;
        public const int BadRequest = 400;
        public const int NotFound = 404;
        public const int InternalServerError = 500;
    }
}
