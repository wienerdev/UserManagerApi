using System.ComponentModel.DataAnnotations;

namespace Manager.Api.ViewModels
{
    public class AuthViewModel
    {

        [Required(ErrorMessage = "O login não pode ser vazio.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazio.")]
        public string Password { get; set; }
    }
}
