﻿namespace FreelanceSite.Entities
{
    public class ProjectsCategories
    {
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
