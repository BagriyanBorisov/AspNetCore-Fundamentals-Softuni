namespace TaskBoard.Common.Validations
{
    public static class EntityValidations
    {
        public static class TaskValidations
        {
            public const int MaxTitleLength = 70;
            public const int MinTitleLength = 5;

            public const int MaxDescriptionLength = 1000;
            public const int MinDescriptionLength = 10;
        }

        public static class BoardValidations
        {
            public const int MaxNameLength = 70;
            public const int MinNameLength = 5;

        }
    }
}
