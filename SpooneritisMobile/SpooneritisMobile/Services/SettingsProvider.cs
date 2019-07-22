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

        public void SetItem(SettingTypes setting, string value)
        {
            switch (setting)
            {
                case SettingTypes.Jwt:
                    Settings.Jwt = value;
                    break;
                case SettingTypes.UserId:
                    Settings.UserId = value;
                    break;
                default:
                    break;
            }
        }
    }
}
