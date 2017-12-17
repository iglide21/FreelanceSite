using FreelanceSite.Entities;
using System.Collections.Generic;

namespace FreelanceSite.Services.CommonViewModels.Contracts
{
    public interface IEditCreateViewModeI
    {
        string Title { get; }

        string Description { get; }

        string Skills { get; }

        BudgetViewModel Budget { get; }
    }
}
