using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNote.Common
{
    public static class EntityValidations
    {
        public static class User
        {
           public const int MaxUsernameLength = 20;
           public const int MinUsernameLength = 3;

           public const int MaxFirstNameLength = 15;
           public const int MinFirstNameLength = 3;

           public const int MaxLastNameLength = 15;
           public const int MinLastNameLength = 3;

           public const int MaxEmailLength = 64;
           public const int MinEmailLength = 5;
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
            public const int MinTitleLength = 1;

            public const int MaxSubtitleLength = 50;
            public const int MinSubtitleLength = 1;
        }
    }
}
