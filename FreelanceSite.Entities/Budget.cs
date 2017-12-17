using FreelanceSite.Infrastructure.Constants;

namespace FreelanceSite.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Budget
    {
        public int Id { get; set; }

        [Range(BudgetLowerBound, BudgetHigherBound)]
        public decimal LowerBound { get; set; }

        [Range(BudgetLowerBound,BudgetHigherBound)]
        public decimal HigherBound { get; set; }

        public IEnumerable<Project> Projects { get; set; } = new List<Project>();
    }
}
