namespace FreelanceSite.Services
{
    using FreelanceSite.Services.CommonViewModels;
    using System.Collections.Generic;

    public interface IBudgetService
    {
        IEnumerable<BudgetViewModel> GetAll();
    }
}
