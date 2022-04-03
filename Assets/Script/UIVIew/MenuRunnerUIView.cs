using System.Collections;
using System.Collections.Generic;
using Script.Core;
using Script.Models;
using Script.Service;
using Script.UIVIew;
using UnityEngine;
using UnityEngine.UI;

public class MenuRunnerUIView : UIView
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        Initialize();

            
        playButton.onClick.AddListener(PlayLevel);
        settingsButton.onClick.AddListener(() => GameContext.Instance.ShowView(nameof(SettingsRunnerUIView)));
        exitButton.onClick.AddListener(Application.Quit);
    }
    private void PlayLevel()
    {
        var pm = GameContext.Instance.SaveService.Load<ProgressModel>();
        var asyncOperation = GameContext.Instance.SceneService.LoadScene($"Level_{pm.currentLevel}");
        asyncOperation.completed += operation =>
        {
            GameContext.Instance.HideView();
        };
    }

    public override string ViewName => nameof(MenuRunnerUIView);

}
