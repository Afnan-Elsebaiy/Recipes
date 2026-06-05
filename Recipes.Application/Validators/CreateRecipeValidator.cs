using FluentValidation;
using Recipes.Application.DTOs.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Application.Validators
{
    public class CreateRecipeValidator
       : AbstractValidator<CreateRecipeDto>
    {
        public CreateRecipeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.Calories)
                .GreaterThan(0);

            RuleFor(x => x.Protein)
                .GreaterThanOrEqualTo(0);
        }
    }
}
