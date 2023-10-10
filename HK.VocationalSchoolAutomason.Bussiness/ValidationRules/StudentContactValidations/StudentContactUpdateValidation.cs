using FluentValidation;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentContactDtos;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;

public class StudentContactUpdateValidation : AbstractValidator<StudentContactUpdateDto>
{
    public StudentContactUpdateValidation()
    {
        RuleFor(contact => contact.City)
            .NotEmpty().WithMessage("Şehir alanı gereklidir.");

        RuleFor(contact => contact.District)
            .NotEmpty().WithMessage("İlçe alanı gereklidir.");

        RuleFor(contact => contact.Neighbourhood)
            .NotEmpty().WithMessage("Mahalle alanı gereklidir.");

        RuleFor(contact => contact.Address)
            .NotEmpty().WithMessage("Adres alanı gereklidir.");

        RuleFor(contact => contact.PhoneNumber)
            .NotEmpty().WithMessage("Telefon numarası alanı gereklidir.")
            .Matches(@"^\d{10}$").WithMessage("Geçerli bir telefon numarası giriniz.");

        RuleFor(contact => contact.PhoneNumber2)
            .Must(BeValidPhoneNumberOrEmpty).WithMessage("Geçerli bir telefon numarası giriniz veya boş bırakınız.");


    }

    // Özel bir kural: PhoneNumber2, boş veya geçerli bir telefon numarası olmalıdır.
    private bool BeValidPhoneNumberOrEmpty(string phoneNumber2)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber2))
        {
            return true; // Boş bırakılabilir.
        }

        return phoneNumber2.Length == 10 && System.Text.RegularExpressions.Regex.IsMatch(phoneNumber2, @"^\d{10}$");
    }
}
