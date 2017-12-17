namespace FreelanceSite.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FreelanceSite.Data;
    using FreelanceSite.Services.CommonViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryService : ICategoryService
    {
        private readonly FreelanceSiteDbContext db;

        public CategoryService(FreelanceSiteDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CategoryListingViewModel> GetAll()
        {
            var categories = this.db
            .Categories
            .ProjectTo<CategoryListingViewModel>()
            .ToList();

            return categories;
        } 
    }
}
