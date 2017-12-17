
namespace FreelanceSite.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FreelanceSite.Data;
    using FreelanceSite.Services.CommonViewModels;
    using System.Collections.Generic;
    using System.Linq;

    public class BudgetService : IBudgetService
    {
        private readonly FreelanceSiteDbContext db;

        public BudgetService(FreelanceSiteDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BudgetViewModel> GetAll()
        {
            var budgets = this.db.Budgets
                .ProjectTo<BudgetViewModel>().ToList();

            return budgets;
        }
    }
}
