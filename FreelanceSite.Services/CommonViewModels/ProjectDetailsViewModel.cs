namespace FreelanceSite.Services.CommonViewModels
{
    using AutoMapper;
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;

    public class ProjectDetailsViewModel : IMapFrom<Project>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public BudgetViewModel Budget { get; set; }

        public string Title { get; set; }

        public string Skills { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public void Configure(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(cfg => cfg.Budget, opt => opt.MapFrom(p => p.Budget));
        }
    }
}
