using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.DayValidation
{
    public class DayCreateValidation : AbstractValidator<DayCreateDto>
    {
        public DayCreateValidation()
        {
            RuleFor(dto => dto.Days)
                .NotEmpty().WithMessage("Günler alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Günler alanı en fazla 50 karakter olabilir.");
        }
    }
}
