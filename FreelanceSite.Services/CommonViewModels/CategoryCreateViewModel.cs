using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Services.CommonViewModels
{
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class CategoryCreateViewModel : IMapFrom<Category>
    {
        [Required]
        [MinLength(CategoryTitleMinLength)]
        [MaxLength(CategoryTitleMaxLength)]
        public string Title { get; set; }
    }
}
