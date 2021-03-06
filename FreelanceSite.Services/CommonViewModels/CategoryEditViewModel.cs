﻿using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Services.CommonViewModels
{
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class CategoryEditViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryTitleMinLength)]
        [MaxLength(CategoryTitleMaxLength)]
        public string Title { get; set; }
    }
}
