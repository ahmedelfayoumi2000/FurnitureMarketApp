using FluentValidation;
using FurnitureMarketApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.email).NotEmpty().EmailAddress().WithMessage("Please enter a valid email.");
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters.");
            RuleFor(x => x.user_phone).Matches(@"^\d{10,15}$").When(x => !string.IsNullOrEmpty(x.user_phone)).WithMessage("Please enter a valid phone number.");
        }
    }
}
