using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyLessonHoursDtos;
using System;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.WeeklyLessonHoursValidation
{
    public class WeeklyLessonHoursUpdateValidation : AbstractValidator<WeeklyLessonHoursUpdateDto>
    {
        public WeeklyLessonHoursUpdateValidation()
        {
            RuleFor(dto => dto.Id)
                .GreaterThan(0).WithMessage("Geçerli bir kimlik sağlanmalıdır.");

            RuleFor(dto => dto.StartTime)
                .LessThan(dto => dto.EndTime).WithMessage("Başlangıç zamanı, bitiş zamanından önce olmalıdır.");
        }
    }
}
