using System.ComponentModel.DataAnnotations;

namespace ProjektZaliczeniowyASP.NET.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Proszę podać swoje imię i nazwisko.")]
        [Display(Name = "Pełne imię i nazwisko")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Proszę podać adres e-mail.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu e-mail.")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać hasło.")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są zgodne.")]
        public string ConfirmPassword { get; set; }
    }
}
