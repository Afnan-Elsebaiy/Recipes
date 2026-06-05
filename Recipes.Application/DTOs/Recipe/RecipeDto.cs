using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.DTOs.Recipe
{
    public class RecipeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
