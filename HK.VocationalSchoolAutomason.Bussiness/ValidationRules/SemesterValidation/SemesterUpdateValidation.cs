using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.SemesterValidation
{
    public class SemesterUpdateValidation : AbstractValidator<SemesterUpdateDto>
    {
        public SemesterUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Dönem ID boş olamaz.")
                .GreaterThan(0).WithMessage("Dönem ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Dönem adı boş olamaz.")
                .MaximumLength(255).WithMessage("Dönem adı en fazla 255 karakter olabilir.");
        }
    }
}
