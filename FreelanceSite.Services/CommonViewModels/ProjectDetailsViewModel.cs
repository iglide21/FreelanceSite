﻿namespace FreelanceSite.Services.CommonViewModels
{
    using AutoMapper;
    using FreelanceSite.Entities;
    using FreelanceSite.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.Linq;

    public class ProjectDetailsViewModel : IMapFrom<Project>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public BudgetViewModel Budget { get; set; }

        public string Title { get; set; }

        public string Skills { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public List<Bid> Bids { get; set; }

        public void Configure(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsViewModel>()
                .ForMember(cfg => cfg.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(cfg => cfg.UserName, opt => opt.MapFrom(p => p.User.UserName))
                .ForMember(cfg => cfg.Budget, opt => opt.MapFrom(p => p.Budget))
                .ForMember(cfg => cfg.Bids, opt => opt.MapFrom(p => p.Bids));
        }
    }
}
