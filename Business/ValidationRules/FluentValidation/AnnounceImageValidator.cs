using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AnnounceImageValidator:AbstractValidator<AnnounceImage>
    {
        public AnnounceImageValidator()
        {
            RuleFor(x => x.AnnounceId).NotEmpty();
            RuleFor(x => x.AnnounceId).GreaterThan(0);

        }
    }
}
