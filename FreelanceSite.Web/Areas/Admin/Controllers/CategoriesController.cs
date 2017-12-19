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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.RedirectToAction(nameof(All));
            }

            var category = this.categories.GetForEdit(id);

            if (category == null)
            {
                return this.RedirectToAction(nameof(All));
            }

            return this.View(category);
        }
    }
}
