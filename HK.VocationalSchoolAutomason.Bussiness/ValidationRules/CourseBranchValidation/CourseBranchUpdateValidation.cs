using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseBranchDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.CourseBranchValidation
{
    public class CourseBranchUpdateValidation : AbstractValidator<CourseBranchUpdateDto>
    {
        public CourseBranchUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kurs Branş ID boş olamaz.")
                .GreaterThan(0).WithMessage("Kurs Branş ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Kurs ID boş olamaz.")
                .GreaterThan(0).WithMessage("Kurs ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Branş ID boş olamaz.")
                .GreaterThan(0).WithMessage("Branş ID geçerli bir değer olmalıdır.");
        }
    }
}
