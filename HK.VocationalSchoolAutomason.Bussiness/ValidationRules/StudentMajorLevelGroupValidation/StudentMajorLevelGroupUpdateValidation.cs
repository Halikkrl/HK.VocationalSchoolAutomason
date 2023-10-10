using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentMajorLevelGroupDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.StudentMajorLevelGroupValidation
{
    public class StudentMajorLevelGroupUpdateValidation : AbstractValidator<StudentMajorLevelGroupUpdateDto>
    {
        public StudentMajorLevelGroupUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("Kimlik Kimliği boş olamaz.");

            RuleFor(dto => dto.StudentId)
                .NotEmpty().WithMessage("Öğrenci Kimliği boş olamaz.");

            RuleFor(dto => dto.MajorLevelGroupId)
                .NotEmpty().WithMessage("Bölüm Düzey Grubu Kimliği boş olamaz.");

            RuleFor(dto => dto.SemesterId)
                .NotEmpty().WithMessage("Dönem Kimliği boş olamaz.");

            RuleFor(dto => dto.TotalContinuity)
                .NotEmpty().WithMessage("Toplam Süreklilik boş olamaz.")
                .GreaterThanOrEqualTo(0).WithMessage("Toplam Süreklilik 0'dan küçük olamaz.");
        }
    }
}
