
using Script.Core;
using Script.Models;
using Script.Service;
using UnityEngine;
using UnityEngine.UI;
namespace Script.UIVIew
{
    public class LevelCompletedRunnerUIView : UIView
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private Button nextButton;

        [SerializeField] private Text CoinText;
        [SerializeField] private Text timeText;

        public override string ViewName => nameof(LevelCompletedRunnerUIView);
        private void Awake()
        {
            Initialize();
            
            nextButton.onClick.AddListener(NextLevel);
            menuButton.onClick.AddListener(() =>
            {
                GameContext.Instance.ShowView(nameof(MenuRunnerUIView));
                var pm = GameContext.Instance.SaveService.Load<ProgressModel>();
                pm.currentLevel=1;
                GameContext.Instance.SaveService.Write(pm);
            });
            restartButton.onClick.AddListener(RestartLevel);
        }
        private void NextLevel()
        {
            var pm = GameContext.Instance.SaveService.Load<ProgressModel>();
            var asyncOperation = GameContext.Instance.SceneService.LoadScene($"Level_{pm.currentLevel}");
            asyncOperation.completed += operation =>
            {
                GameContext.Instance.HideView();
            };
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
            // var asyncOperation = GameContext.Instance.SceneService.LoadScene($"Level_{pm.currentLevel-1}");
            //asyncOperation.completed += operation => { GameContext.Instance.HideView(); };
        }

        private void Update()
        {
            timeText.text = LevelUIView.RealTime.ToString();
            CoinText.text = PlauerMov.CoinDisp.ToString();
        }
    }
}