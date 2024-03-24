namespace DotNote.Common
{
    public static class EntityValidations
    {
        public static class User
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;
        }

        public static class Folder
        {
            public const int MaxNameLength = 15;
            public const int MinNameLength = 1;
        }

        public static class Update
        {
            public const int MaxTitleLength = 50;
            public const int MinTitleLength = 3;

            public const int MaxDescriptionLength = 1000;
            public const int MinDescriptionLength = 10;
        }

        public static class Note
        {
            public const int MaxTitleLength = 50;
            public const int MinTitleLength = 3;

            public const int MaxSubtitleLength = 50;

            public const int MaxTextLength = 1000;
        }
        
    }
}
