
using Script.Core;
using Script.Models;
using Script.Service;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
namespace Script.UIVIew
{
    public class GameOverRunnerUIView : UIView
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        
        public override string ViewName => nameof(GameOverRunnerUIView);

        private void Awake()
        {
            Initialize();
            
            restartButton.onClick.AddListener(RestartLevel);
            menuButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(MenuRunnerUIView));
                var pm = GameContext.Instance.SaveService.Load<ProgressModel>();
                pm.currentLevel=1;
                GameContext.Instance.SaveService.Write(pm);
            });
        }

        private void RestartLevel()
        {
            var pm = GameContext.Instance.SaveService.Load<ProgressModel>();
            if (pm.currentLevel == 1)
            {
                var asyncOperation = GameContext.Instance.SceneService.LoadScene($"Level_{pm.currentLevel}");
                asyncOperation.completed += operation => { GameContext.Instance.HideView(); };
            }
            else
            {
                var asyncOperation = GameContext.Instance.SceneService.LoadScene($"Level_{pm.currentLevel - 1}");
                asyncOperation.completed += operation => { GameContext.Instance.HideView(); };
            }
            
        }
       
    }


}