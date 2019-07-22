using SpooneritisMobile.Helpers;

namespace SpooneritisMobile.Services
{
    public interface ISettingsProvider
    {
        string GetItem(SettingTypes setting);

        void SetItem(SettingTypes setting, string value);
    }
}
