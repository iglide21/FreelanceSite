namespace FreelanceSite.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int UserUsernameMinLength = 6;
        public const int UserUsernameMaxLength = 25;

        public const int UserFirstNameMinLength = 2;
        public const int UserFirstNameMaxLength = 30;

        public const int UserLastNameMinLength = 2;
        public const int UserLastNameMaxLength = 30;

        public const int BudgetLowerBound = 0;
        public const int BudgetHigherBound = 1500;

        public const int CategoryTitleMinLength = 2;
        public const int CategoryTitleMaxLength = 30;

        public const int ProjectTitleMinLength = 20;
        public const int ProjectTitleMaxLength = 50;

        public const int ProjectDescriptionMinLength = 30;
        public const int ProjectDescriptionMaxLength = 500;

        public const int UserBioMinLength = 20;
        public const int UserBioMaxLength = 300;
    }
}
