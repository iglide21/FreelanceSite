using FreelanceSite.Entities;
using FreelanceSite.Infrastructure.Mapping;

namespace FreelanceSite.Services.Models
{
    public class SingleUserListingViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
