using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : MonoBehaviour
{
    private float startingTime, currentTimeElapsed;
    public float currentTime;
    public int currentTimeInt;
    private float nextActionTime = 0.0f;
    private float period = 1.0f;
    public Text timeText;

    private void Start()
    {
        currentTimeInt = 0;
        currentTime = 0;
    }

    private void Update()
    {
        if (GetComponent<CheckIfTargetActive>().trackerFound())
        {
            currentTime += 1.0f * Time.deltaTime;
            currentTimeInt = Mathf.RoundToInt(currentTime);
        }
        timeText.text = currentTimeInt.ToString();
    }

    private void IncrementTime()
    {
        currentTimeInt++;
        return;
    }
}
