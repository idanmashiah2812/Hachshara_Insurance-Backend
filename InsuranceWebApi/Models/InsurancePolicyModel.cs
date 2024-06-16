using System.ComponentModel.DataAnnotations;

namespace InsuranceWebApi.Models
{
    /// <summary>
    /// This class represent a model that contains Insurance policy info, e.g. Policy Number, UserId that connected to this policy, etc
    /// </summary>
    public class InsurancePolicyModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string PolicyNumber { get; set; }

        [Required]
        public int InsuranceAmount { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
