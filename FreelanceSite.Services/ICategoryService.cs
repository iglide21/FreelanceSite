namespace FreelanceSite.Services
{
    using FreelanceSite.Services.CommonViewModels;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<CategoryListingViewModel> GetAll();

        void Update(int id, string title);

        string GetById(int? categoryId);

        void Delete(int? id);

        void Create(string title);
    }
}
