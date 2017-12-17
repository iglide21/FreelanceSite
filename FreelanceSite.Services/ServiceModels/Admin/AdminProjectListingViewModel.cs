namespace FreelanceSite.Services.Models
{
    using AutoMapper;
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;

    public class AdminProjectListingViewModel : IMapFrom<Project>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Owner { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Budget Budget { get; set; }

        public string Skills { get; set; }

        public void Configure(Profile profile)
        {
            profile.CreateMap<Project, AdminProjectListingViewModel>()
                .ForMember(cfg => cfg.Owner, opt => opt.MapFrom(p => p.User.UserName));
        }
    }
}
