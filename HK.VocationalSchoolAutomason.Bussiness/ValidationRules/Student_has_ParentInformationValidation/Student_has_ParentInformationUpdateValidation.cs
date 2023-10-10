using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Student_has_ParentInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.Student_has_ParentInformationValidation
{
    public class Student_has_ParentInformationUpdateValidation : AbstractValidator<Student_has_ParentInformationUpdate>
    {
        public Student_has_ParentInformationUpdateValidation()
        {
            RuleFor(model => model.StudentId)
                .NotEmpty().WithMessage("Öğrenci ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir öğrenci ID girin.");

            RuleFor(model => model.ParentInformationId)
                .NotEmpty().WithMessage("Veli Bilgisi ID boş olamaz.")
                .GreaterThan(0).WithMessage("Geçerli bir veli bilgisi ID girin.");
        }
    }
}
