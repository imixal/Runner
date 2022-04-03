
using Script.Core;
using Script.Models;
using Script.Service;
using UnityEngine;
using UnityEngine.UI;
namespace Script.UIVIew
{
    public class SettingsRunnerUIView : UIView
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Toggle audioToggle;
        
        private void Awake()
        {
            Initialize();

            var sm = GameContext.Instance.SaveService.Load<SettingsModel>();

            volumeSlider.value = sm.volume;
            volumeSlider.minValue = 0;
            volumeSlider.maxValue = 1;
            audioToggle.isOn = sm.mute;

            backButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(MenuRunnerUIView)));
            volumeSlider.onValueChanged.AddListener(v =>
            {
                GameContext.Instance.AudioService.Volume = v;
                var settingsModel = GameContext.Instance.SaveService.Load<SettingsModel>();
                settingsModel.volume = v;
                GameContext.Instance.SaveService.Write(settingsModel);
                
            });
            audioToggle.onValueChanged.AddListener(v =>
            {
                GameContext.Instance.AudioService.Mute = v;
                var settingsModel = GameContext.Instance.SaveService.Load<SettingsModel>();
                settingsModel.mute = v;
                GameContext.Instance.SaveService.Write(settingsModel);
            });
        }

        public override string ViewName => nameof(SettingsRunnerUIView);
    }
}