using System.ComponentModel.DataAnnotations;

namespace BlogFoodApi.ViewModel
{
    public class RegistrationModel
    {


        [Required]
        public string UserName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

    }
}
