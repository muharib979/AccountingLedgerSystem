using Core.Application.Commands.Accounts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Commands.Accounts
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Account name is required.");
            RuleFor(x => x.Type).NotEmpty().WithMessage("Account type is required.");
        }
    }
}
