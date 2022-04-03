using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIView : MonoBehaviour
{
    
    [SerializeField] private Text timeText;
    public static float RealTime;
    
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = timeToDisplay % 60;
        timeText.text = $"{minutes:0}:{seconds:00}";
    }

    

    private void Update()
    {
        RealTime += Time.deltaTime;
        DisplayTime(RealTime);
    }
    
}
