using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Student_has_ParentInformation;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.Student_has_ParentInformation
{
    public class Student_has_ParentInformationCreateValidation : AbstractValidator<Student_has_ParentInformationCreate>
    {
        public Student_has_ParentInformationCreateValidation()
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
