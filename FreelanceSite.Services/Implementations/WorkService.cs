namespace FreelanceSite.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using FreelanceSite.Data;
    using FreelanceSite.Entities;
    using FreelanceSite.Services;
    using FreelanceSite.Services.CommonViewModels;
    using FreelanceSite.Services.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class WorkService : IWorkService
    {
        private readonly FreelanceSiteDbContext db;

        public WorkService(FreelanceSiteDbContext db)
        {
            this.db = db;
        }


        public void CreateProject(string userId, string modelTitle, string modelDescription, int modelBudgetId, string modelSkills, IEnumerable<int> categories)
        {
            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);

            var project = new Project
            {
                User = user,
                Title = modelTitle,
                Description = modelDescription,
                BudgetId = modelBudgetId,
                Skills = modelSkills,
            };

            this.db.Projects.Add(project);
            this.db.SaveChanges();


            SetCategories(categories, project.Id);
        }


        public IEnumerable<AdminProjectListingViewModel> AllProjects()
        {
            var projects = db
                .Projects
                .ProjectTo<AdminProjectListingViewModel>()
                .ToList();

            return projects;
        }

        public bool Exists(int? id)
        {
            if (id == null)
            {
                return false;
            }

            return this.db.Projects.Any(c => c.Id == id);
        }

        public EditProjectViewModel GetProjectForEdit(int? id)
        {
            var proj = this.db.Projects
                .Where(p => p.Id == id)
                .ProjectTo<EditProjectViewModel>()
                .FirstOrDefault();

            return proj;
        }

        public void Update(int id, string title, string description, string skills, List<int> categories, BudgetViewModel budget)
        {
            var project = this.db
                .Projects
                .Include(p => p.Categories)
                .SingleOrDefault(p => p.Id == id);

            project.Title = title;
            project.Description = description;
            project.Skills = skills;
            project.BudgetId = budget.Id;

            project.Categories = new List<ProjectsCategories>();

            db.SaveChanges();

            this.SetCategories(categories, project.Id);

            this.db.SaveChanges();
        }

        private void SetCategories(
            IEnumerable<int> categories,
            int projectId)
        {
            var project = this.db
                .Projects
                .Where(p => p.Id == projectId)
                .Include(p => p.Categories)
                .FirstOrDefault();

            foreach (var category in categories)
            {
                project.Categories.Add(new ProjectsCategories
                {
                    CategoryId = category,
                    ProjectId = project.Id
                });
            }

            this.db.SaveChanges();
        }

        public bool Remove(int? id)
        {
            var project = this.db.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return false;
            }

            this.db.Remove(project);
            this.db.SaveChanges();

            return true;
        }
    }
}