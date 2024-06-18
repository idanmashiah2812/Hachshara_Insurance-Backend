using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.Models
{
    /// <summary>
    /// This class represent a model of user that contains user basic info, e.g. User id, username and email of that user
    /// </summary>
    public class UserModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email address is not a valid address")]
        public string Email { get; set; }
    }
}
