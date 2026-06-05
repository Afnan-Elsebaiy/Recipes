using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Common.Responses
{
    public enum ResponseType
    {
        Success,
        Created,
        Failed,
        NotFound,
        Unauthorized,
        ValidationError
    }
}
