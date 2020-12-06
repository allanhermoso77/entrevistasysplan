using FluentValidation;

namespace SysplanSolution.API.ViewModels.Validations
{
    public class ClienteViewModelValidator : AbstractValidator<ClienteViewModel>
    {
        public ClienteViewModelValidator()
        {
            RuleFor(user => user.Nome).NotEmpty().WithMessage("Nome não pode ser vazio");
            RuleFor(user => user.Idade).NotEmpty().WithMessage("Idade não pode ser vazio");
        }
    }
}
