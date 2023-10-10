using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDutyDtos;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.EmployeeDutyValidation
{
    public class EmployeeDutyUpdateValidation : AbstractValidator<EmployeeDutyUpdateDto>
    {
        public EmployeeDutyUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("Çalışan görev ID boş olamaz.")
                .GreaterThan(0).WithMessage("Çalışan görev ID geçerli bir değer olmalıdır.");

            RuleFor(dto => dto.EmployeeId)
                .NotEmpty().WithMessage("Çalışan ID boş olamaz.")
                .GreaterThan(0).WithMessage("Çalışan ID geçerli bir değer olmalıdır.");

            RuleFor(dto => dto.DutyId)
                .NotEmpty().WithMessage("Görev ID boş olamaz.")
                .GreaterThan(0).WithMessage("Görev ID geçerli bir değer olmalıdır.");
        }
    }
}
