using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.SemesterValidation
{
    public class SemesterCreateValidation : AbstractValidator<SemesterCreateDto>
    {
        public SemesterCreateValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Dönem adı boş olamaz.")
                .MaximumLength(255).WithMessage("Dönem adı en fazla 255 karakter olabilir.");
        }
    }
}
