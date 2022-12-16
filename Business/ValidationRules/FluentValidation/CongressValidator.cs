using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CongressValidator : AbstractValidator<Congress>
    {
        public CongressValidator()
        {
            RuleFor(x => x.CongressAbout).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.CongressCity).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.CongressDate).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.CongressName).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.CongressPlace).NotEmpty().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.CongressStatus).NotEmpty().WithMessage("Bu alan boş geçilemez");

        }
    }
}
