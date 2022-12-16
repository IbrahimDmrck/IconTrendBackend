using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ScienceBoardValidator : AbstractValidator<ScienceBoard>
    {
        public ScienceBoardValidator()
        {
            RuleFor(x => x.ScienceBoardMemberName).NotEmpty().WithMessage("Bu alanı boş geçemezsin");
            RuleFor(x => x.CongressId).NotEmpty().WithMessage("Bu alanı boş geçemezsin");
            RuleFor(x => x.Univercity).NotEmpty().WithMessage("Bu Alanı boş geçmeyin");
        }
    }
}
