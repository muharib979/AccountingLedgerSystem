using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Commands.Journal
{
    public class CreateJournalEntryValidator : AbstractValidator<CreateJournalEntryCommand>
    {
        public CreateJournalEntryValidator()
        {
            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");

            //RuleFor(x => x.Description)
            //    .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.Lines)
                .NotEmpty().WithMessage("At least one journal entry line is required.");

            RuleFor(x => x.Lines.Sum(x => x.Debit))
                .Equal(x => x.Lines.Sum(x => x.Credit))
                .WithMessage("Total debit must equal total credit.");
        }
    }
}
