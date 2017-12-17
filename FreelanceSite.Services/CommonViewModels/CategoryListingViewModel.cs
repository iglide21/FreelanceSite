namespace FreelanceSite.Services.CommonViewModels
{
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;

    public class CategoryListingViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
