namespace FreelanceSite.Services
{
    using FreelanceSite.Services.CommonViewModels;
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IEnumerable<CategoryListingViewModel> GetAll();
        CategoryEditViewModel GetForEdit(int? id);
    }
}
