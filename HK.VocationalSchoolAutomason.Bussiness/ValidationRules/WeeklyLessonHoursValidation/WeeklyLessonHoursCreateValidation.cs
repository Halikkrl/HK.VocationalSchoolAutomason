using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyLessonHoursDtos;
using System;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.WeeklyLessonHoursValidation
{
    public class WeeklyLessonHoursCreateValidation : AbstractValidator<WeeklyLessonHoursCreateDto>
    {
        public WeeklyLessonHoursCreateValidation()
        {
            RuleFor(dto => dto.StartTime)
                .LessThan(dto => dto.EndTime).WithMessage("Başlangıç zamanı, bitiş zamanından önce olmalıdır.");
        }
    }
}
