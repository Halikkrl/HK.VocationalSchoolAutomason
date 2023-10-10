using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.DayValidation
{
    public class DayUpdateValidation : AbstractValidator<DayUpdateDto>
    {
        public DayUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .GreaterThan(0).WithMessage("Geçerli bir kimlik sağlanmalıdır.");

            RuleFor(dto => dto.Days)
                .NotEmpty().WithMessage("Günler alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Günler alanı en fazla 50 karakter olabilir.");
        }
    }
}
