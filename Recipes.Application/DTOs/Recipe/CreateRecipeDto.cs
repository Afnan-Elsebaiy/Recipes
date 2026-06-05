using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.DTOs.Recipe
{
    public class CreateRecipeDto
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int Calories { get; set; }

        public int Protein { get; set; }
    }
}
