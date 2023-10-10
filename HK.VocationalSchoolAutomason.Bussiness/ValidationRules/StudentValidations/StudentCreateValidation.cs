using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using System;
using System.Text.RegularExpressions;

public class StudentCreateValidation : AbstractValidator<StudentCreateDto>
{
    public StudentCreateValidation()
    {
        RuleFor(x => x.IdentificationNumber)
            .NotEmpty().WithMessage("Kimlik numarası boş olamaz.")
            .Length(11).WithMessage("Kimlik numarası 11 karakter uzunluğunda olmalıdır.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş olamaz.")
            .MaximumLength(50).WithMessage("Ad en fazla 50 karakter uzunluğunda olmalıdır.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş olamaz.")
            .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter uzunluğunda olmalıdır.");

        RuleFor(x => x.Number)
            .GreaterThan(0).WithMessage("Numara pozitif bir değer olmalıdır.");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Cinsiyet boş olamaz.");

        RuleFor(x => x.DateOfBirthDay)
            .Must(BeAValidDate).WithMessage("Doğum tarihi geçersiz.");

        RuleFor(x => x.Photo)
            .Null().When(x => x.Photo == null).WithMessage("Fotoğraf alanı boş bırakılabilir.");

        RuleFor(x => x.RepeatingAGrade)
            .Must(IsValidRepeatingAGrade)
            .WithMessage("Sınıf tekrarı bilgisi geçersiz. 0, 1, 2 gibi değerler kullanılmalıdır.");

    }

    private bool BeAValidDate(DateTime date)
    {
        return date <= DateTime.Now;
    }

    private bool IsValidRepeatingAGrade(string grade)
    {
        return string.IsNullOrEmpty(grade) || Regex.IsMatch(grade, "^[0-2]$");
    }
}


