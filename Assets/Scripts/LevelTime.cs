using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTime : MonoBehaviour
{
    private float startingTime, currentTimeElapsed;
    private int currentTimeInt;
    private float nextActionTime = 0.0f;
    private float period = 1.0f;
    public Text timeText;

    private void Start()
    {
        currentTimeInt = 0;
    }

    private void Update()
    {
        if(Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (GetComponent<CheckIfTargetActive>().trackerFound())
            {
                currentTimeInt++;
            }
        }
        timeText.text = currentTimeInt.ToString();
    }
}
