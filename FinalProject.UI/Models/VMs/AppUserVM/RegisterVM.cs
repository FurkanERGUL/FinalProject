using System.ComponentModel.DataAnnotations;

namespace FinalProject.UI.Models.VMs.AppUserVM
{
    public class RegisterVM
    {
        [Display(Name = "Kullanıcı adı")]
        [Required]
        public string UserName { get; set; }


        [Display(Name = "Email adresi")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Telefon")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Şifre")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Maksimum 10 en az 3 olmalı", MinimumLength = 3)]
        public string Password { get; set; }

        [Display(Name = "Şifre onay")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girilen şifreler aynı olmalıdır.")]
        [StringLength(10, ErrorMessage = "Maksimum 10 en az 3 olmalı", MinimumLength = 3)]
        public string ConfirmPassword { get; set; }
    }
}
