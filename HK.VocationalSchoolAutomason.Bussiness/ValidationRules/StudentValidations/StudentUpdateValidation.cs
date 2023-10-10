using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using System;

namespace HK.VocationalSchoolAutomason.Bussiness.ValidationRules.StudentValidations
{
    public class StudentUpdateValidation : AbstractValidator<StudentUpdateDto>
    {
        public StudentUpdateValidation()
        {
            RuleFor(student => student.IdentificationNumber)
                .NotEmpty().WithMessage("Kimlik numarası boş olamaz.")
                .Length(11).WithMessage("Kimlik numarası 11 karakter uzunluğunda olmalıdır.");

            RuleFor(student => student.FirstName)
                .NotEmpty().WithMessage("Ad boş olamaz.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter uzunluğunda olmalıdır.");

            RuleFor(student => student.LastName)
                .NotEmpty().WithMessage("Soyad boş olamaz.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter uzunluğunda olmalıdır.");

            RuleFor(student => student.Number)
                .GreaterThan(0).WithMessage("Numara pozitif bir değer olmalıdır.");

            RuleFor(student => student.Gender)
                .NotEmpty().WithMessage("Cinsiyet boş olamaz.");

            RuleFor(student => student.DateOfBirthDay)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Doğum tarihi gelecekte olamaz.");

            RuleFor(student => student.IsActive)
                .NotNull().WithMessage("Aktiflik durumu belirtilmelidir.");

            RuleFor(student => student.RepeatingAGrade)
                .NotEmpty().WithMessage("Sınıf tekrarı bilgisi boş olamaz.");

        }
    }
}
