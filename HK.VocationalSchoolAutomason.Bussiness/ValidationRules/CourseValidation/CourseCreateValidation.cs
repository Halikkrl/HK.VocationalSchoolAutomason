using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.CourseValidation
{
    public class CourseCreateValidation : AbstractValidator<CourseCreateDto>
    {
        public CourseCreateValidation()
        {
            RuleFor(course => course.Name)
                .NotEmpty().WithMessage("Kurs adı boş olamaz.")
                .MaximumLength(100).WithMessage("Kurs adı en fazla 100 karakter olmalıdır.");

            RuleFor(course => course.IsActive)
                .NotNull().WithMessage("Aktiflik durumu belirtilmelidir.");
        }
    }
}
