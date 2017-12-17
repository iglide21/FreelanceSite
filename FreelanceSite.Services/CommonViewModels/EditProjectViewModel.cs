namespace FreelanceSite.Services.CommonViewModels
{
    using AutoMapper;
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using FreelanceSite.Services.CommonViewModels.Contracts;
    using System.Collections.Generic;

    public class EditProjectViewModel : IEditCreateViewModeI, IMapFrom<Project>, IHaveCustomMapping
    {
        public int Id { get; set;  }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Skills { get; set; }

        public List<int> ProjectCategories { get; set; }

        public BudgetViewModel Budget { get; set; }

        public void Configure(Profile profile)
        {
            profile.CreateMap<Project, EditProjectViewModel>()
                .ForMember(opt => opt.Budget, cfg => cfg.MapFrom(m => m.Budget));
        }
    }
}

