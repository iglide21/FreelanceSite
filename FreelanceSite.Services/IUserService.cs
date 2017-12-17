using FreelanceSite.Services.CommonViewModels;

namespace FreelanceSite.Services
{
    public interface IUserService
    {
        UserDetailsViewModel GetUserDetails(string username);
    }
}
