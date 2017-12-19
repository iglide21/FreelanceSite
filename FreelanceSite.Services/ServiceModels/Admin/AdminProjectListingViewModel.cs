namespace FreelanceSite.Services.Models
{
    using AutoMapper;
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminProjectListingViewModel : IMapFrom<Project>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Owner { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int BidsCount { get; set; }

        public Budget Budget { get; set; }

        public string Skills { get; set; }

        public void Configure(Profile profile)
        {
            profile.CreateMap<Project, AdminProjectListingViewModel>()
                .ForMember(cfg => cfg.Owner, opt => opt.MapFrom(p => p.User.UserName))
                .ForMember(cfg => cfg.BidsCount, opt => opt.MapFrom(p => p.Bids.Count));
        }
    }
}
