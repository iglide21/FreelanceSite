namespace FreelanceSite.Web.Controllers
{
    using FreelanceSite.Entities;
    using FreelanceSite.Services;
    using FreelanceSite.Services.CommonViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;

    public class ProjectsController : Controller
    {
        private readonly IBudgetService budgets;
        private readonly IWorkService works;
        private readonly ICategoryService categories;
        private readonly UserManager<User> userManager;

        public ProjectsController(IBudgetService budgets, IWorkService works, UserManager<User> userManager, ICategoryService categories)
        {
            this.budgets = budgets;
            this.works = works;
            this.categories = categories;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var projects = this.works.AllProjects();

            return this.View(projects);
        }

        public IActionResult Create()
        {
            this.BudgetsAndCategoriesToViewBag();

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProjectViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.works.CreateProject(this.User.Identity.Name, model.Title, model.Description, model.Budget.Id, model.Skills, model.Categories);

            this.TempData["SuccessMessage"] = "Project created successfully. Go to \"My Projects\" to view your projects.";

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int? id)
        {
            bool exists = this.works.Exists(id);

            if (!exists)
            {
                return this.RedirectToAction(nameof(All));
            }

            this.BudgetsAndCategoriesToViewBag();

            var project = this.works.GetProjectForEdit(id);

            return this.View(project);
        }

        [HttpPost]
        public IActionResult Edit(EditProjectViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.works.Update(model.Id, model.Title, model.Description, model.Skills, model.ProjectCategories, model.Budget);

            this.TempData["SuccessMessage"] = "Project edited successfully. Go to \"My Projects\" to view your projects.";

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.RedirectToAction(nameof(All));
            }

            bool deleted = this.works.Remove(id);

            if (deleted == true)
            {
                this.TempData["DeleteMessage"] = $"Project with id {id} was deleted.";
                return this.RedirectToAction(nameof(All));
            }

            return this.RedirectToAction(nameof(All));
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
