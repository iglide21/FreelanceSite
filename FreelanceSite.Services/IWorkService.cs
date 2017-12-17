namespace FreelanceSite.Services
{
    using FreelanceSite.Services.CommonViewModels;
    using FreelanceSite.Services.Models;
    using System.Collections.Generic;

    public interface IWorkService
    {
        void CreateProject(string userName,
            string modelTitle, 
            string modelDescription, 
            int modelBudgetId,
            string modelSkills,
            IEnumerable<int> categories);

        IEnumerable<AdminProjectListingViewModel> AllProjects();

        bool Exists(int? id);

        EditProjectViewModel GetProjectForEdit(int? id);

        void Update(int id, string title, string description, string skills, List<int> categories, BudgetViewModel budget);
        bool Remove(int? id);
    }
}
