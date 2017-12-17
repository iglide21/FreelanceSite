namespace FreelanceSite.Services.CommonViewModels
{
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;

    public class BudgetViewModel : IMapFrom<Budget>
    {
        public int Id { get; set; }

        public decimal LowerBound { get; set; }

        public decimal HigherBound { get; set; }
    }
}
