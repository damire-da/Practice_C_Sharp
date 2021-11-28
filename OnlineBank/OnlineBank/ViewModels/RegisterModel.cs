using System.ComponentModel.DataAnnotations;

namespace OnlineBank.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Не указано имя!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан возраст!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Не указан email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно!")]
        public string ConfirmPassword { get; set; }
    }
}
