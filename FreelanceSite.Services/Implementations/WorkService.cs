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


        public void CreateProject(string userName, string modelTitle, string modelDescription, int modelBudgetId, string modelSkills, IEnumerable<int> categories)
        {
            var user = this.db.Users.FirstOrDefault(u => u.UserName == userName);

            var project = new Project
            {
                User = user,
                Title = modelTitle,
                Description = modelDescription,
                BudgetId = modelBudgetId,
                Skills = modelSkills,
                IsActive = true,
                IsCompleted = false
            };

            this.db.Projects.Add(project);
            this.db.SaveChanges();


            SetCategories(categories, project.Id);
        }

        public IEnumerable<AdminProjectListingViewModel> AllActiveProjects()
            => db
                .Projects
                .Where(p => p.IsCompleted == false && p.IsActive == true)
                .ProjectTo<AdminProjectListingViewModel>()
                .ToList();

        public IEnumerable<AdminProjectListingViewModel> AllProjects()
            => db
                .Projects
                .ProjectTo<AdminProjectListingViewModel>()
                .ToList();

        public IEnumerable<AdminProjectListingViewModel> AllActiveProjects(int? categoryId, string searchTerm)
        {
            var projects = db
                .Projects
                .Where(p => p.IsActive == true && p.IsCompleted == false)
                .Include(p => p.Categories)
                .Where(p => p.Title.Contains(searchTerm)
                         || p.Description.Contains(searchTerm));

            if (categoryId != null)
            {
                int catId = (int)categoryId;

                projects = projects.Where(p => p.Categories.Any(c => c.CategoryId == catId));
            }

            return projects
                .ProjectTo<AdminProjectListingViewModel>()
                .ToList();
        }

        public bool Exists(int? id)
        {
            if (id == null)
            {
                return false;
            }

            return this.db.Projects
                .Where(p=>p.IsActive == true)
                .Any(c => c.Id == id);
        }

        public EditProjectViewModel GetProjectForEdit(int? id)
        {
            var proj = this.db.Projects
                .Where(p => p.Id == id)
                .ProjectTo<EditProjectViewModel>()
                .SingleOrDefault();

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

        public bool SetUnactive(int? id)
        {
            var project = this.db.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return false;
            }

            project.IsActive = false;
            this.db.SaveChanges();

            return true;
        }

        public void Remove(int? id)
        {
            var project = this.db.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null)
            {
                return;
            }

            this.db.Projects.Remove(project);
            this.db.SaveChanges();
        }

        public ProjectDetailsViewModel GetProjectDetails(int? id)
        => this.db
            .Projects
            .Where(p => p.Id == id 
                && p.IsActive == true && p.IsCompleted == false)
            .ProjectTo<ProjectDetailsViewModel>()
            .SingleOrDefault();

        public bool IsOwner(int? id, string userUserName)
        => this.db
            .Projects
            .Include(p => p.User)
            .Where(p => p.Id == id)
            .Select(p => p.User.UserName)
            .SingleOrDefault() == userUserName;


        public string GetProjectNameById(int? id)
        => this.db
            .Projects
            .Where(p => p.Id == id)
            .Select(p=>p.Title)
            .SingleOrDefault();

        public bool IsActive(int? id)
        {
            if (id == null)
            {
                return false;
            }

            return this.db
                       .Projects
                       .Where(p => p.Id == id)
                       .Select(p => p.IsActive)
                       .SingleOrDefault();
        }

        public void Activate(int? id)
        {
            var project = this.db.Projects.SingleOrDefault(p => p.Id == id);

            project.IsActive = true;
            project.IsCompleted = false;

            this.db.SaveChanges();
        }

        public void Deactivate(int? id)
        {
            var project = this.db.Projects.SingleOrDefault(p => p.Id == id);

            project.IsActive = false;

            this.db.SaveChanges();
        }

        public void SetCompleted(int projectId)
        {
            var project = this.db.Projects.SingleOrDefault(p => p.Id == projectId);

            project.IsActive = false;
            project.IsCompleted = true;

            this.db.SaveChanges();
        }
    }
}