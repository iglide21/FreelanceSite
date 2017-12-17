using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryTitleMinLength)]
        [MaxLength(CategoryTitleMaxLength)]
        public string Title { get; set; }

        public List<ProjectsCategories> Projects { get; set; } = new List<ProjectsCategories>();
    }
}
