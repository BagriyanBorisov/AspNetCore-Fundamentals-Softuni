namespace TaskBoard.Common.Validations
{
    public static class EntityValidations
    {
        public static class TaskValidations
        {
            public const int MaxTitleLength = 70;
            public const int MinTitleLength = 5;
            public const string ErrorMsgTitle = "Title should be at least {2} characters long.";

            public const int MaxDescriptionLength = 1000;
            public const int MinDescriptionLength = 10;
            public const string ErrorMsgDescription = "Description should be at least {2} characters long.";
        }

        public static class BoardValidations
        {
            public const int MaxNameLength = 70;
            public const int MinNameLength = 5;

        }
    }
}
