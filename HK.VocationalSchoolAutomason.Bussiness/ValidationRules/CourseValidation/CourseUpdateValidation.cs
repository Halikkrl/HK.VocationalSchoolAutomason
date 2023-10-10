using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.CourseValidation
{
    public class CourseUpdateValidation : AbstractValidator<CourseUpdateDto>
    {
        public CourseUpdateValidation()
        {
            RuleFor(course => course.Id)
                .GreaterThan(0).WithMessage("Geçerli bir kurs kimliği belirtilmelidir.");

            RuleFor(course => course.Name)
                .NotEmpty().WithMessage("Kurs adı boş olamaz.")
                .MaximumLength(100).WithMessage("Kurs adı en fazla 100 karakter olmalıdır.");

            RuleFor(course => course.IsActive)
                .NotNull().WithMessage("Aktiflik durumu belirtilmelidir.");
        }
    }
}
