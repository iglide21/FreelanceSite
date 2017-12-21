namespace FreelanceSite.Services.Implementations
{
    using FreelanceSite.Data;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using FreelanceSite.Entities;
    using Microsoft.EntityFrameworkCore;

    public class BidService : IBidService
    {
        private readonly FreelanceSiteDbContext db;

        public BidService(FreelanceSiteDbContext db)
        {
            this.db = db;
        }

        public void Add(decimal value, int period, int projectId, string ownerUsername, DateTime creationDate)
        {
            var user = this.db
                .Users
                .Where(u => u.UserName == ownerUsername)
                .Include(u => u.Bids)
                .SingleOrDefault();

            var project = this.db
                .Projects
                .Where(p => p.Id == projectId)
                .Include(p => p.Bids)
                .SingleOrDefault();

            var bid = new Bid();

            var havePlacedBid = project.Bids.Any(b => b.OwnerUserName == user.UserName);

            if (havePlacedBid)
            {
                bid = project.Bids.SingleOrDefault(b => b.OwnerUserName == user.UserName);
                project.Bids.Remove(bid);
                this.db.SaveChanges();
            }

            bid = new Bid()
            {
                Period = period,
                Value = value,
                User = user,
                UserId = user.Id,
                OwnerUserName = ownerUsername,
                ProjectId = project.Id,
                Project = project,
                CreationDate = creationDate
            };

            this.db.Bids.Add(bid);
            this.db.SaveChanges();
        }
    }
}
