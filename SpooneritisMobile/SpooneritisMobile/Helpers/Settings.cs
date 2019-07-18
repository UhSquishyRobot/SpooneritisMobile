using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SpooneritisMobile.Helpers
{
    public static class Settings
    {
        private static readonly string _jwtKey = "SpooneritisJwt";
        private static readonly string _userIdKey = "SpooneritisUserId";

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string Jwt
        {
            get
            {
                return AppSettings.GetValueOrDefault(_jwtKey, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(_jwtKey, value);
            }
        }

        public static string UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(_userIdKey, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(_userIdKey, value);
            }
        }
    }
}