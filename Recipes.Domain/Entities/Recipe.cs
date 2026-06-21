using Recipes.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int Calories { get; set; }


        public int Protein { get; set; }
    }
}
