using FluentValidation;

namespace Application.Features.ShoppingMethods.Commands.UpdateShoppingMethod
{
    public class UpdateShoppingMethodValidator : AbstractValidator<UpdateShoppingMethodCommand>
    {
        public UpdateShoppingMethodValidator()
        {
            RuleFor(c => c.Name)
                      .NotEmpty().WithMessage(m => "The Name Not Allowed be Empty")
                      .NotNull().WithMessage(m => "The Name Not Equal  Null")
                      .MinimumLength(3).WithMessage(m => "The Name Not  be less than 3")
                      .MaximumLength(50).WithMessage(m => "The Name Not be more than 50 char");
       
        }
    }
}
