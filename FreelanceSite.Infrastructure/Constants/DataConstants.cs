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

        public const int ContestMinDays = 1;
        public const int ContestMaxDays = 60;

        public const int JobLocationMinLength = 5;
        public const int JobLocationMaxLength = 30;

        public const int WorkDetailTitleMinLength = 5;
        public const int WorkDetailTitleMaxLength = 30;

        public const int WorkDetailDescriptionMinLength = 20;
        public const int WorkDetailDescriptionMaxLength = 500;
    }
}
