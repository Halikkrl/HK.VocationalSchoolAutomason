using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.GradeSystemDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.GradeSystemValidation
{
    public class GradeSystemUpdateValidation : AbstractValidator<GradeSystemUpdateDto>
    {
        public GradeSystemUpdateValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Not Sistemi ID boş olamaz.")
                .GreaterThan(0).WithMessage("Not Sistemi ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.CourseId)
                .NotEmpty().WithMessage("Kurs ID boş olamaz.")
                .GreaterThan(0).WithMessage("Kurs ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.StudentMajorLevelGroupId)
                .NotEmpty().WithMessage("Öğrenci Anahtar Seviye Grup ID boş olamaz.")
                .GreaterThan(0).WithMessage("Öğrenci Anahtar Seviye Grup ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.NoteOne)
                .GreaterThanOrEqualTo(0).WithMessage("Not 1 negatif olamaz.");

            RuleFor(x => x.NoteTwo)
                .GreaterThanOrEqualTo(0).WithMessage("Not 2 negatif olamaz.");

            RuleFor(x => x.NoteThree)
                .GreaterThanOrEqualTo(0).WithMessage("Not 3 negatif olamaz.");

            RuleFor(x => x.OralGrade)
                .GreaterThanOrEqualTo(0).WithMessage("Sözlü not negatif olamaz.");

            RuleFor(x => x.Average)
                .GreaterThanOrEqualTo(0).WithMessage("Ortalama not negatif olamaz.");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("Durum belirtilmelidir.");
        }
    }
}
