using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.SemesterWeekDtos;
using System;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.SemesterWeekValidation
{
    public class SemesterWeekCreateValidation : AbstractValidator<SemesterWeekCreateDto>
    {
        public SemesterWeekCreateValidation()
        {
            RuleFor(x => x.SemesterId)
                .NotEmpty().WithMessage("Dönem ID boş olamaz.")
                .GreaterThan(0).WithMessage("Dönem ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.WeeksId)
                .NotEmpty().WithMessage("Hafta ID boş olamaz.")
                .GreaterThan(0).WithMessage("Hafta ID geçerli bir değer olmalıdır.");

            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage("Başlangıç zamanı belirtilmelidir.")
                .Must(BeAValidDate).WithMessage("Başlangıç zamanı geçerli bir tarih olmalıdır.");

            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage("Bitiş zamanı belirtilmelidir.")
                .Must(BeAValidDate).WithMessage("Bitiş zamanı geçerli bir tarih olmalıdır.")
                .GreaterThan(x => x.StartTime).WithMessage("Bitiş zamanı başlangıç zamanından sonra olmalıdır.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
