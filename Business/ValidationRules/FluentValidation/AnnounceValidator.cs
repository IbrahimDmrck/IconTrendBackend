using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AnnounceValidator : AbstractValidator<Announcement>
    {

        public AnnounceValidator()
        {
            RuleFor(x => x.AnnounceTitle).NotEmpty().WithMessage("Bu alanı boş geçmeyin");
            RuleFor(x => x.AnnounceStatus).NotEmpty().WithMessage("Bu alanı boş geçmeyin");
            RuleFor(x => x.AnnounceDate).NotEmpty().WithMessage("Bu alanı boş geçmeyin");
            RuleFor(x => x.AnnounceContent).NotEmpty().WithMessage("Bu alanı boş geçmeyin");

        }
    }
}
