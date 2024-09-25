using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Kullanıcı Adı veya E-posta")]
    public string UsernameOrEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
