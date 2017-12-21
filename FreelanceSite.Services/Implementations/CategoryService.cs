namespace FreelanceSite.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FreelanceSite.Data;
    using FreelanceSite.Entities;
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

        public void Create(string title)
        {
            var category = new Category()
            {
                Title = title
            };

            this.db.Categories.Add(category);
            this.db.SaveChanges();
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                return;
            }

            var category = this.db.Categories.SingleOrDefault(c => c.Id == id);
            this.db.Categories.Remove(category);
            this.db.SaveChanges();
        }

        public IEnumerable<CategoryListingViewModel> GetAll()
        {
            var categories = this.db
            .Categories
            .ProjectTo<CategoryListingViewModel>()
            .ToList();

            return categories;
        }

        public string GetById(int? categoryId)
        => this.db
            .Categories
            .Where(c => c.Id == categoryId)
            .FirstOrDefault()
            .Title;

        public void Update(int id, string title)
        {
            var category = this.db
                           .Categories
                           .SingleOrDefault(c => c.Id == id);

            category.Title = title;

            this.db.SaveChanges();
        }
    }
}
