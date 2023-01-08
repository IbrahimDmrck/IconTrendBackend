using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SaveValidator:AbstractValidator<Save>
    {
        public SaveValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama Alanı Boş Bırakılamaz");
            RuleFor(x=>x.OralPresentationMemberPrice).NotEmpty().WithMessage("Fiyat Bilgisi Alanı Boş Bırakılamaz");
            RuleFor(x=>x.OralPresentationNonMemberPrice).NotEmpty().WithMessage("Fiyat Bilgisi Alanı Boş Bırakılamaz");
            RuleFor(x=>x.VideoConferenceMemberPrice).NotEmpty().WithMessage("Fiyat Bilgisi Alanı Boş Bırakılamaz");
            RuleFor(x=>x.VideoConferenceNonMemberPrice).NotEmpty().WithMessage("Fiyat Bilgisi Alanı Boş Bırakılamaz");

            RuleFor(x=>x.VideoConferenceDescription).NotEmpty().WithMessage("Videolu Konferans Açıklama Alanı Boş Bırakılamaz");
            RuleFor(x=>x.VideoConferenceDescription).NotEmpty().WithMessage("Videolu Konferans Açıklama Alanı Boş Bırakılamaz");
        }
    }
}
