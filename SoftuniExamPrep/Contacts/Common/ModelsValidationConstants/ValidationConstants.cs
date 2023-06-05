namespace Contacts.Common.ModelsValidationConstants
{
    public static class ValidationConstants
    {
        public static class ContactValidations
        {
            public const int ContactNameMaxLength = 50;
            public const int ContactNameMinLength = 2;
            public const int ContactLastNameMinLength = 5;

            public const string ContactPhonePattern =
                @"^(?:(?:\+359|0)\s?(?:\d{12}|\d{10})|(?:\+359|0)[-\s]?\d{3}[-\s]?\d{2}[-\s]?\d{2}[-\s]?\d{2})$";

            public const string ContactPhoneErrorMsg = "This is not valid Phone Number";

            public const int ContactEmailMaxLength = 60;

            public const string ContactWebsitePattern = @"^www\.[a-zA-Z0-9\-]+\.bg$";
            public const string ContactWebsiteErrorMsg = "This is not valid Website Url";

            public const int ContactNumberMaxLength = 13;
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
