using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRewards : MonoBehaviour
{
    private int[] rewardValues;
    public int threeStar, twoStar;
    private int currentMoves;
    public Text debug;
    
    void Start()
    {
        rewardValues = new int[3];
        rewardValues[0] = threeStar;
        rewardValues[1] = twoStar;
        currentMoves = 0;
    }


    void Update()
    {
        currentMoves = GetComponent<MoveTracker>().currentMoves;
        if(currentMoves <= rewardValues[0])
        {
            debug.text = "3 Stars!";
        }
        else if(currentMoves <= rewardValues[1] && currentMoves > rewardValues[0])
        {
            debug.text = "2 Stars!";
        }
        else
        {
            debug.text = "1 Star!";
        }
    }
}
