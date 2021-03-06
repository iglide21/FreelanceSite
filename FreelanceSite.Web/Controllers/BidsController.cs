﻿using FreelanceSite.Services;
using FreelanceSite.Services.CommonViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceSite.Web.Controllers
{
    public class BidsController : Controller
    {
        private readonly IBidService bids;
        private readonly IUserService users;
        private readonly IWorkService projects;

        public BidsController(IBidService bids,IUserService users,IWorkService projects)
        {
            this.bids = bids;
            this.users = users;
            this.projects = projects;
        }

        [HttpPost]
        public IActionResult Add(BidAddViewModel model)
        {
            model.CreationDate = DateTime.Now;
            model.OwnerUsername = this.User.Identity.Name;

            this.bids.Add(model.Value, model.Period,model.ProjectId, model.OwnerUsername, model.CreationDate);

            return this.RedirectToAction("Details","Projects",new { id = model.ProjectId});
        }

        public IActionResult Accept(string ownerId, int projectId)
        {
            this.users.UpdateCompletedProjects(ownerId);
            this.projects.SetCompleted(projectId);

            return this.RedirectToAction(nameof(ProjectsController.All), "Projects");
        }
    }
}
