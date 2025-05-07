using FluentValidation;
using FurnitureMarketApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.Validators
{
    public class FurnitureItemDtoValidator : AbstractValidator<FurnitureItemDto>
    {
        public FurnitureItemDtoValidator()
        {
            RuleFor(x => x.title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.category).NotEmpty().WithMessage("Category is required.");
            RuleFor(x => x.price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
