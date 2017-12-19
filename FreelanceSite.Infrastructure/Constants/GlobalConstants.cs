using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FreelanceSite.Infrastructure.Constants
{
    public static class GlobalConstants
    {
        public const string AdministratorRole = "Administrator";
        public const string ModeratorRole = "Moderator";
        public const string FreelancerRole = "Freelancer";

        public const string SuccessMessage = "SuccessMessage";
        public const string DeleteMessage = "DeleteMessage";
        public const string NotExistingMessage = "NotExistingMessage";

        public static List<string> AllRoles()
        {
            var fields = typeof(GlobalConstants).GetFields(BindingFlags.Static
                                                           | BindingFlags.Public
                                                           | BindingFlags.FlattenHierarchy);

            System.Console.WriteLine();

            List<string> roles = new List<string>();

            foreach (var item in fields.Where(f => f.Name.Contains("Role")))
            {
                if (item.Name.EndsWith("Role"))
                {
                    var indexOrRole = item.Name.IndexOf("Role");

                    string name = item.Name.Substring(0, indexOrRole);

                    roles.Add(name);
                }
            }


            return roles;
        }
    }
}
