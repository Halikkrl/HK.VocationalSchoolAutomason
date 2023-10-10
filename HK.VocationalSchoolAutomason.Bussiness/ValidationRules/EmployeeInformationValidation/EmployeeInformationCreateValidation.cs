using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeInformationDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeInformationValidation
{
    public class EmployeeInformationCreateValidation : AbstractValidator<EmployeeInformationCreateDto>
    {
        public EmployeeInformationCreateValidation()
        {
            RuleFor(e => e.EmployeeId)
                .NotEmpty().WithMessage("Çalışan ID'si boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir çalışan ID'si giriniz.");

            RuleFor(e => e.Graduation)
                .NotEmpty().WithMessage("Mezuniyet alanı boş olamaz.")
                .MaximumLength(50).WithMessage("Mezuniyet alanı en fazla 50 karakter içerebilir.");

            RuleFor(e => e.GraduationYear)
                .NotEmpty().WithMessage("Mezuniyet yılı boş olamaz.")
                .Matches(@"^\d{4}$").WithMessage("Geçerli bir yıl formatı giriniz (örn. 2023).");

            RuleFor(e => e.GraduatedSchool)
                .NotEmpty().WithMessage("Mezun olduğu okul boş olamaz.")
                .MaximumLength(100).WithMessage("Mezun olduğu okul en fazla 100 karakter içerebilir.");
        }
    }
}
