namespace FreelanceSite.Services.CommonViewModels
{
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using System.Collections.Generic;

    public class UserDetailsViewModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastSeen { get; set; }

        public string Biography { get; set; }

        public string Role { get; set; }

        public string PhoneNumber { get; set; }

        public List<ProjectDetailsViewModel> Projects { get; set; }


        public void Configure(Profile profile)
        {
            profile.CreateMap<User, UserDetailsViewModel>()
                .ForMember(cfg => cfg.Projects, opt => opt.MapFrom(u => u.Projects));
        }
    }
}
