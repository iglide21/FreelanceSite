namespace FreelanceSite.Services.CommonViewModels
{
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using FreelanceSite.Services.CommonViewModels.Contracts;
    using System.Collections.Generic;

    public class CreateProjectViewModel : IEditCreateViewModeI, IMapFrom<Project>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Skills { get; set; }

        public List<int> Categories { get; set; }

        public BudgetViewModel Budget { get; set; }
    }
}
