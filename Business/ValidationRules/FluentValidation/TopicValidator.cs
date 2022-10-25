using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TopicValidator : AbstractValidator<Topic>
    {
        public TopicValidator()
        {
            RuleFor(x => x.Category).NotEmpty().WithMessage("Bu alanı boş geçemezsin");
            RuleFor(x => x.CongressId).NotEmpty().WithMessage("Bu alanı boş geçemezsin");
            RuleFor(x => x.TopicName).NotEmpty().WithMessage("Bu alanı boş geçemezsin");
           
        }
    }
}
