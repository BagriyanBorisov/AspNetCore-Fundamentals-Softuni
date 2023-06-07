namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.ValidationConstants.Validations.UserValidations;
    public class RegisterViewModel
    {
        [Required]
        [StringLength(UserNameMaxLength,MinimumLength = UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(UserPassMaxLength)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;


    }
}
