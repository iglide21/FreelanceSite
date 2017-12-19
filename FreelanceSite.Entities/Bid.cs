using System.ComponentModel.DataAnnotations;

namespace FreelanceSite.Entities
{
    public class Bid
    {
        public int Id { get; set; }

        [Required]
        [Range(0,double.MaxValue, ErrorMessage ="Service price cannot be below 0")]
        public decimal Value { get; set; } //in dollars

        [Required]
        [Range(0,90, ErrorMessage = "Period for the project to be done have to be between 0 and 90 days")]
        public int Period { get; set; } //in days

        public string OwnerUserName { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
