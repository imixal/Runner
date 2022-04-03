/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Finish : MonoBehaviour
{
 //   [SerializeField] private GameObject Panel;
    
    private void OnTriggerEnter(Collider other)
    {
        
       var x = SceneManager.GetActiveScene().buildIndex;
       x++;
       if (x < 5)
       {
           SceneManager.LoadScene(x);
       }
       else
       {
           Panel.SetActive(true);
       }

    }
}
*/
using System.Collections;
using System.Collections.Generic;
using Script.Core;
using Script.Service;
using Script.UIVIew;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Script.Models
{
    public class Finish : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("finish level");

            GameContext.Instance.ShowView(nameof(LevelCompletedRunnerUIView));

            var pm = GameContext.Instance.SaveService.Load<ProgressModel>();
            pm.currentLevel++;
            GameContext.Instance.SaveService.Write(pm);
            // GameContext.Instance.SaveService.White(pm);

            var scene = SceneManager.GetActiveScene().name;
            GameContext.Instance.SceneService.UnLoadScene(scene);
            Debug.Log(scene);
        }
    }
}