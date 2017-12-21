namespace FreelanceSite.Services
{
    using FreelanceSite.Entities;
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

        IEnumerable<AdminProjectListingViewModel> AllActiveProjects(int? categoryId, string searchTerm);

        IEnumerable<AdminProjectListingViewModel> AllActiveProjects();

        IEnumerable<AdminProjectListingViewModel> AllProjects();

        bool Exists(int? id);

        EditProjectViewModel GetProjectForEdit(int? id);

        void Update(int id, string title, string description, string skills, List<int> categories, BudgetViewModel budget);

        void Activate(int? id);

        void Deactivate(int? id);

        bool SetUnactive(int? id);

        void Remove(int? id);

        ProjectDetailsViewModel GetProjectDetails(int? id);

        bool IsOwner(int? id, string userUserName);

        string GetProjectNameById(int? id);

        bool IsActive(int? id);

        void SetCompleted(int projectId);
    }
}
