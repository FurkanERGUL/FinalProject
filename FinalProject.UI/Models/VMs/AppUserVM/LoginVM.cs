using System.ComponentModel.DataAnnotations;

namespace FinalProject.UI.Models.VMs.AppUserVM
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Kullanıcı email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
