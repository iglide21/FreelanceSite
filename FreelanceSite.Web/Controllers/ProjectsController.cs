namespace FreelanceSite.Web.Controllers
{
    using FreelanceSite.Entities;
    using FreelanceSite.Services;
    using FreelanceSite.Services.CommonViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System;

    public class ProjectsController : Controller
    {
        private readonly IBudgetService budgets;
        private readonly IWorkService projects;
        private readonly ICategoryService categories;
        private readonly UserManager<User> userManager;

        public ProjectsController(IBudgetService budgets, IWorkService works, UserManager<User> userManager, ICategoryService categories)
        {
            this.budgets = budgets;
            this.projects = works;
            this.categories = categories;
            this.userManager = userManager;
        }

        public IActionResult All(int? categoryId, string searchTerm = "")
        {
            var projects = this.projects.AllActiveProjects(categoryId, searchTerm ?? "");

            if (categoryId != null)
            {
                var categoryName = this.categories.GetById(categoryId);
                ViewBag.SelectedCategoryName = categoryName;
                ViewBag.SelectedCategoryId = categoryId;
            }


            ViewBag.SearchTerm = searchTerm;

            this.BudgetsAndCategoriesToViewBag();

            return this.View(projects);
        }

        [Authorize]
        public IActionResult Create()
        {
            this.BudgetsAndCategoriesToViewBag();

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateProjectViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.projects.CreateProject(this.User.Identity.Name, model.Title, model.Description, model.Budget.Id, model.Skills, model.Categories);

            this.TempData["SuccessMessage"] = "Project created successfully. Go to \"My Profile\" to view your projects.";

            return this.RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (!CanProceed(id))
            {
                return this.RedirectToAction(nameof(All));
            }

            bool exists = this.projects.Exists(id);

            if (!exists)
            {
                this.TempData["NotExisting"] = "This project do not exists or it is not active.";
                return this.RedirectToAction(nameof(All));
            }

            this.BudgetsAndCategoriesToViewBag();

            var project = this.projects.GetProjectForEdit(id);

            return this.View(project);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(EditProjectViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.projects.Update(model.Id, model.Title, model.Description, model.Skills, model.ProjectCategories, model.Budget);

            this.TempData["SuccessMessage"] = "Project edited successfully. Go to \"My Projects\" to view your projects.";

            return this.RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (!CanProceed(id))
            {
                return this.RedirectToAction(nameof(All));
            }

            string projectName = this.projects.GetProjectNameById(id);
            bool deleted = this.projects.SetUnactive(id);

            if (deleted == true)
            {
                this.TempData["DeleteMessage"] = $"Your project {projectName} was deleted.";
                return this.RedirectToAction(nameof(All));
            }

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Details(int? id)
        {
            var project = this.projects.GetProjectDetails(id);

            if (project == null)
            {
                this.TempData["NotExisting"] = "Project do not exists or it is not active.";
                return this.RedirectToAction(nameof(All));
            }

            return this.View(project);
        }

        private bool CanProceed(int? id)
        {
            if (this.User.IsInRole("Administrator") || this.User.IsInRole("Moderator"))
            {
                return true;
            }

            return this.projects.IsActive(id) && IsAllowedToDo(id);
        }

        private bool IsAllowedToDo(int? id)
        {
            if (id == null)
            {
                this.RedirectToAction(nameof(All));
            }

            var userUserName = this.User.Identity.Name;

            return this.projects.IsOwner(id, userUserName);
        }

        private void BudgetsAndCategoriesToViewBag()
        {
            this.ViewBag.Categories = this.categories.GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = $"{c.Title}",
                    Value = $"{c.Id}"
                });


            this.ViewBag.Budgets = this.budgets.GetAll()
                .Select(b => new SelectListItem()
                {
                    Text = $"{b.LowerBound} - {b.HigherBound}",
                    Value = $"{b.Id}"
                });
        }
    }
}
