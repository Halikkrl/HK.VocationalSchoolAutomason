using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeDutyValidation
{
    public class EmployeeDutyCreateValidation : AbstractValidator<EmployeeDutyCreateDto>
    {
        public EmployeeDutyCreateValidation()
        {
            RuleFor(dto => dto.EmployeeId)
                .NotEmpty().WithMessage("Çalışan ID boş olamaz.")
                .GreaterThan(0).WithMessage("Çalışan ID geçerli bir değer olmalıdır.");

            RuleFor(dto => dto.DutyId)
                .NotEmpty().WithMessage("Görev ID boş olamaz.")
                .GreaterThan(0).WithMessage("Görev ID geçerli bir değer olmalıdır.");
        }
    }
}
