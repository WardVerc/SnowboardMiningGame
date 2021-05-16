using System.ComponentModel.DataAnnotations;

namespace ActionCommandGame.Ui.WebApp.ViewModels
{
    public class PlayerViewModel
    {
        [Display(Name = "Player's name: ")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Length of name must be in range of 4-20.")]
        public string Name { get; set; }
        
        [Display(Name = "Password: ")]
        [Required(ErrorMessage = "You must have a password.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Length of password must be in range of 4-20.")]
        public string Password { get; set; }
    }
}