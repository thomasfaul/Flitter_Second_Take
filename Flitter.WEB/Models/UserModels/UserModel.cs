using Flitter.RESOURCES;
using System.ComponentModel.DataAnnotations;

namespace Flitter.WEB.Models.UserModels
{
    public class UserModel
    {
        [Display(Name = Constants.Labels.ID, ResourceType = typeof(ValidationLabels))]
        public int ID { get; set; }

        public string Salt { get; set; }

        [Display(Name = Constants.Labels.USERROLE, ResourceType = typeof(ValidationLabels))]
        public string Role { get; set; }

        [Display(Name = Constants.Labels.FIRSTNAME, ResourceType = typeof(ValidationLabels))]
        public byte[] Pic { get; set; }
    }
}