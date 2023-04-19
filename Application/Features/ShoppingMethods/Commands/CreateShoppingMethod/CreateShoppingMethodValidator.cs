using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ShoppingMethods.Commands.CreateShoppingMethod
{
    public class CreateShoppingMethodValidator: AbstractValidator<CreateShoppingMethodCommand>
    {
        public CreateShoppingMethodValidator() {
            RuleFor(c => c.Name)
                      .NotEmpty().WithMessage(m => "The Name Not Allowed be Empty")
                      .NotNull().WithMessage(m => "The Name Not Equal  Null")
                      .MinimumLength(3).WithMessage(m => "The Name Not  be less than 3")
                      .MaximumLength(50).WithMessage(m => "The Name Not be more than 50 char");
        }
    }
}
