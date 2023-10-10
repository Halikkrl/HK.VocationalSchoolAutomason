using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.ClassLessonDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.ClassLessonValidation
{
    public class ClassLessonUpdateValidation : AbstractValidator<ClassLessonUpdateDto>
    {
        public ClassLessonUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Ders ID boş olamaz.")
                .GreaterThan(0).WithMessage("Ders ID geçerli bir değer olmalıdır.");

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
