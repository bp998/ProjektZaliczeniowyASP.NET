using System.ComponentModel.DataAnnotations;

namespace ProjektZaliczeniowyASP.NET.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Proszę podać adres e-mail.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu e-mail.")]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać hasło.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
