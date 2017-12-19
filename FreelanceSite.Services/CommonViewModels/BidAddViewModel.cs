using FreelanceSite.Entities;
using FreelanceSite.Infrastructure.Mapping;
using System;

namespace FreelanceSite.Services.CommonViewModels
{
    public class BidAddViewModel : IMapFrom<Bid>
    {
        public string OwnerUsername { get; set; }

        public DateTime CreationDate { get; set; }

        public int ProjectId { get; set; }

        public decimal Value { get; set; }

        public int Period { get; set; } //indays
    }
}
