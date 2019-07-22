using SpooneritisMobile.Helpers;

namespace SpooneritisMobile.Services
{
    // really going to want to rethink all this...
    public class SettingsProvider : ISettingsProvider
    {
        public string GetItem(SettingTypes setting)
        {
            switch (setting)
            {
                case SettingTypes.Jwt:
                    return Settings.Jwt;
                case SettingTypes.UserId:
                    return Settings.UserId;
                default:
                    return "No matching setting";
            }
        }
    }
}
