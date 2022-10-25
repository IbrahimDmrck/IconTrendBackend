using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CongressPresidentValidator : AbstractValidator<CongressPresident>
    {
        public CongressPresidentValidator()
        {
            RuleFor(x => x.CongressPresidentName).NotEmpty().WithMessage("Bu alanı boş geçemezsin");
            RuleFor(x => x.CongressId).NotEmpty().WithMessage("Bu alanı boş geçemezsin");
        }
    }
}
