using System.ComponentModel.DataAnnotations;
using Flitter.RESOURCES;
using Flitter.WEB.Models.UserModels;

namespace Flitter.WEB.Models
{
    public class LoginModel:UserModel
    {
        #region EMAIL
        [Required(
   AllowEmptyStrings = false,
   ErrorMessageResourceType = typeof(ValidationMessages),
   ErrorMessageResourceName = Constants.Validation.REQUIRED)]
        [StringLength(50,
    ErrorMessageResourceType = typeof(ValidationMessages),
   ErrorMessageResourceName = Constants.Validation.MAX_LENGTH)]
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(ValidationMessages),
    ErrorMessageResourceName = Constants.Validation.EMAIL)]
        [Display(Name = Constants.Labels.EMAIL_LABEL, ResourceType = typeof(ValidationLabels))]
        public string Email { get; set; }
        #endregion

        #region PASSWORD
        [Required(
   AllowEmptyStrings = false,
   ErrorMessageResourceType = typeof(ValidationMessages),
   ErrorMessageResourceName = Constants.Validation.REQUIRED
   )]
        [StringLength(maximumLength: 50, MinimumLength = 4,
    ErrorMessageResourceType = typeof(ValidationMessages),
   ErrorMessageResourceName = Constants.Validation.LENGTH)]
        [Display(Name = Constants.Labels.PASSWORD, ResourceType = typeof(ValidationLabels))]
        public string Password { get; set; }
        #endregion
    }
}
