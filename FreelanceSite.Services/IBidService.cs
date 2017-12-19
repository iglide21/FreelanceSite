namespace FreelanceSite.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using System;

    public interface IBidService
    {
        void Add(decimal value, int period, int projectId, string ownerUsername, DateTime creationDate);
    }
}
