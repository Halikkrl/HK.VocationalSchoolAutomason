using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DutiesDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.DutyValidation
{
    public class DutyCreateValidation : AbstractValidator<DutyCreateDto>
    {
        public DutyCreateValidation()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Görev adı boş olamaz.")
                .MaximumLength(100).WithMessage("Görev adı en fazla 100 karakter içerebilir.");
        }
    }
}
