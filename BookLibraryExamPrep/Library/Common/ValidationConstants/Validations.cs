namespace Library.Common.ValidationConstants
{
    public static class Validations
    {
        public static class BookValidations
        {
            public const int BookTitleMaxLength = 50;
            public const int BookTitleMinLength = 10;

            public const int BookAuthorMaxLength = 50;
            public const int BookAuthorMinLength = 5;

            public const int BookDescriptionMaxLength = 5000;
            public const int BookDescriptionMinLength = 5;


        }

        public static class UserValidations
        {
            public const int UserNameMaxLength = 20;
            public const int UserNameMinLength = 5;

            public const int UserEmailMaxLength = 60;
            public const int UserEmailMinLength = 10;

            public const int UserPassMaxLength = 20;
            public const int UserPassMinLength = 5;

        }
    }
}