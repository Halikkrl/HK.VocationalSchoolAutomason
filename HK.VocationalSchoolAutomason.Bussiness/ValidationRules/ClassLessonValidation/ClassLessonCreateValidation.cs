using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassLessonDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.ClassLessonValidation
{
    public class ClassLessonCreateValidation : AbstractValidator<ClassLessonCreateDto>
    {
        public ClassLessonCreateValidation()
        {
            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Kurs ID boş olamaz.")
                .GreaterThan(0).WithMessage("Kurs ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.LGMId)
                .NotEmpty().WithMessage("LGM ID boş olamaz.")
                .GreaterThan(0).WithMessage("LGM ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Aktiflik durumu belirtilmelidir.");
        }
    }
}
