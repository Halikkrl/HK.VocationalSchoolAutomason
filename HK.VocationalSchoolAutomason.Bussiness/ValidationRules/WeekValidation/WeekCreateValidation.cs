using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeksDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.WeekValidation
{
    public class WeekCreateValidation : AbstractValidator<WeeKCreateDto>
    {
        public WeekCreateValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Hafta adı boş olamaz.")
                .MaximumLength(255).WithMessage("Hafta adı en fazla 255 karakter olabilir.");
        }
    }
}
