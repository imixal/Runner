namespace Script.Models
{
    public class SettingsModel
    {
        public float volume;
        public bool mute;

        public SettingsModel()
        {
            volume = 1;
            mute = false;
        }
    }
}