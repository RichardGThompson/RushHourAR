using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : MonoBehaviour
{
    private float startingTime, currentTimeElapsed;
    private int currentTimeInt;
    public Text timeText;

    private void Start()
    {
        startingTime = Time.time;
    }

    private void Update()
    {
        currentTimeElapsed = Time.time - startingTime;
        currentTimeInt = Mathf.RoundToInt(currentTimeElapsed);
        timeText.text = currentTimeInt.ToString();
    }
}
