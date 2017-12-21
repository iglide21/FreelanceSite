using FreelanceSite.Data;
using FreelanceSite.Services;
using FreelanceSite.Services.CommonViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreelanceSite.Web.Areas.Admin.Controllers
{
    public class CategoriesController : AdminController
    {
        private readonly ICategoryService categories;
        private readonly FreelanceSiteDbContext db;

        public CategoriesController(ICategoryService categories, FreelanceSiteDbContext db)
        {
            this.categories = categories;
            this.db = db;
        }

        public IActionResult All()
        {
            var categories = this.categories.GetAll();

            return this.View(categories);
        }

        public IActionResult Create(CategoryCreateViewModel model)
        {
            this.categories.Create(model.Title);

            return this.RedirectToAction(nameof(All));
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel model)
        {
            this.categories.Update(model.Id,model.Title);

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int? id)
        {
            this.categories.Delete(id);

            return this.RedirectToAction(nameof(All));
        }
    }
}
