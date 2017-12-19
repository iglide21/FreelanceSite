namespace FreelanceSite.Services.Implementations
{
    using FreelanceSite.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using FreelanceSite.Entities;

    public class BidService : IBidService
    {
        private readonly FreelanceSiteDbContext db;

        public BidService(FreelanceSiteDbContext db)
        {
            this.db = db;
        }

        public void Add(decimal value, int period, int projectId, string ownerUsername, DateTime creationDate)
        {
            var user = this.db.Users.SingleOrDefault(u => u.UserName == ownerUsername);
            var project = this.db.Projects.SingleOrDefault(p => p.Id == projectId);

            var bid = new Bid()
            {
                Period = period,
                Value = value,
                User = user,
                UserId = user.Id,
                ProjectId = project.Id,
                Project = project
            };

            this.db.Bids.Add(bid);
            this.db.SaveChanges();
        }
    }
}
