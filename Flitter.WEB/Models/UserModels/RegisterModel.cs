using Flitter.RESOURCES;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Flitter.WEB.Models.UserModels
{
    public class RegisterModel:LoginModel
    {
        #region FIRSTNAME
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.REQUIRED)]
        [StringLength(50,
ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.MAX_LENGTH)]
        [RegularExpression(@"^[a-zA-Z--]+$", ErrorMessageResourceType = typeof(ValidationMessages),
    ErrorMessageResourceName = Constants.Validation.SPECIAL_CHARACTER)]
        [Display(Name = Constants.Labels.FIRSTNAME, ResourceType = typeof(ValidationLabels))]
        public string Firstname { get; set; }
        #endregion

        #region LASTNAME
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.REQUIRED)]
        [StringLength(50,
ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.MAX_LENGTH)]
        [RegularExpression(@"^[a-zA-Z--]+$", ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.SPECIAL_CHARACTER)]
        [Display(Name = Constants.Labels.LASTNAME, ResourceType = typeof(ValidationLabels))]
        public string Lastname { get; set; }
        #endregion

        #region USERNAME
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.REQUIRED)]
        [StringLength(50,
ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.MAX_LENGTH)]
        [Display(Name = Constants.Labels.USERNAME, ResourceType = typeof(ValidationLabels))]
        public string Gamertag { get; set; }
        #endregion

        #region BirthDate
        [MinimumAge(18,ErrorMessageResourceType = typeof(ValidationMessages),ErrorMessageResourceName = Constants.Validation.BIRTHDATE_TOO_YOUNG)]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = Constants.Validation.BIRTHDATE)]
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(ValidationMessages),ErrorMessageResourceName = Constants.Validation.BIRTHDATE)]


        [Display(Name = Constants.Labels.BIRTHDATE, ResourceType = typeof(ValidationLabels))]
        public DateTime BirthDate{get; set;}
         #endregion

        #region ADDRESS
            [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.REQUIRED)]
        [StringLength(50,
ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.MAX_LENGTH)]
        [Display(Name = Constants.Labels.ADDRESS, ResourceType = typeof(ValidationLabels))]
        public string Address { get; set; }
        #endregion

        #region CITY
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.REQUIRED)]
        [StringLength(50,
ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.MAX_LENGTH)]
        [Display(Name = Constants.Labels.CITY, ResourceType = typeof(ValidationLabels))]
        public string City { get; set; }
        #endregion

        #region COMPANY
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.REQUIRED)]
        [StringLength(50,
ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.MAX_LENGTH)]
        [Display(Name = Constants.Labels.COMPANY, ResourceType = typeof(ValidationLabels))]
        public string Company { get; set; }
        #endregion

        #region ZIP
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ValidationMessages),
ErrorMessageResourceName = Constants.Validation.REQUIRED)]
        [Display(Name = Constants.Labels.ZIP, ResourceType = typeof(ValidationLabels))]
        public int Zip { get; set; }
        #endregion

        #region PASSWORDCONFIRMATION
        [Required(
        AllowEmptyStrings = false,
        ErrorMessageResourceType = typeof(ValidationMessages),
        ErrorMessageResourceName = Constants.Validation.REQUIRED
        )]
        //[DataType(DataType.Password)]
        [StringLength(50,
     ErrorMessageResourceType = typeof(ValidationMessages),
    ErrorMessageResourceName = Constants.Validation.MAX_LENGTH)]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Password),
    ErrorMessageResourceType = typeof(ValidationMessages),
    ErrorMessageResourceName = Constants.Validation.PASSWORD_EQUAL)]
        [Display(Name = Constants.Labels.CONFIRMATION, ResourceType = typeof(ValidationLabels))]
        public string PasswordConfirmation { get; set; }
        #endregion

        #region TERMS ACCEPTED
        [Required]
        [MustBeSelected(ErrorMessageResourceType = typeof(ValidationMessages), ErrorMessageResourceName = Constants.Validation.TERMS)]
        [Display(Name = Constants.Labels.TERMS_ACCEPT, ResourceType = typeof(ValidationLabels))]
        public bool TermsAccepted { get; set; }

        #endregion



        #region CLASS => ATTRIBUT [MUSTBEATTIBUTE]
        /// <summary>
        /// IClientValidatable for client side Validation
        /// </summary>
        public class MustBeTrueAttribute : ValidationAttribute, IClientValidatable
        {
            #region ISVALID
            /// <summary>
            /// Checks if it is valid
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public override bool IsValid(object value)
            {
                return value is bool && (bool)value;
            }
            #endregion

            #region GetClientValidationRules
            /// <summary>
            /// Implement IClientValidatable for client side Validation
            /// </summary>
            /// <param name="metadata"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "checkbox", ErrorMessage = this.ErrorMessage } };
            }
            #endregion
        }
        #endregion

        #region CLASS => ATTRIBUT [MUSTBESELECTED]
        /// <summary>
        /// Hier wird das Attribut MUSTBESELECTED erstellt und überprüft
        /// </summary>
        public class MustBeSelected : ValidationAttribute, IClientValidatable
        {
            #region ISVALID 
            /// <summary>
            /// Checks if it is valid
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public override bool IsValid(object value)
            {
                if (value == null)
                    return false;
                else
                    return true;
            }
            #endregion

            #region CLIENTVALIDATION RULES
            /// <summary>
            ///  Implement IClientValidatable for client side Validation
            /// </summary>
            /// <param name="metadata"></param>
            /// <param name="context"></param>
            /// <returns></returns>
            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "dropdown", ErrorMessage = this.ErrorMessage } };
            }
            #endregion
        }
        #endregion

        #region MinimumAgeAttribute
        public class MinimumAgeAttribute : ValidationAttribute, IClientValidatable
        {
            int _minimumAge;

            public MinimumAgeAttribute(int minimumAge)
            {
                _minimumAge = minimumAge;
            }

            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "dropdown", ErrorMessage = this.ErrorMessage } };
            }
            public override bool IsValid(object value)
            {
                DateTime date;
                if (DateTime.TryParse(value.ToString(), out date))
                {
                    return date.AddYears(_minimumAge) < DateTime.Now;
                }

                return false;
            }
        }

           
        }
        #endregion
    }
