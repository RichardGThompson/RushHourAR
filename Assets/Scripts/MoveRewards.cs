using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRewards : MonoBehaviour
{
    private int[] rewardValues;
    private int currentScore;
    public int threeStar, twoStar;
    public GameObject starTwo, starThree;
    private Animator starTwoAnimator, starThreeAnimator;
    private int currentMoves;
    public Text debug;
    
    void Start()
    {
        starTwoAnimator = starTwo.GetComponent<Animator>();
        starThreeAnimator = starThree.GetComponent<Animator>();

        rewardValues = new int[3];
        rewardValues[0] = threeStar;
        rewardValues[1] = twoStar;
        currentMoves = 0;
        currentScore = 3;
        debug.text = "3";
    }


    void Update()
    {
        currentMoves = GetComponent<MoveTracker>().currentMoves;
        if(currentMoves == 18)
        {
            currentScore = 2;
            starThreeAnimator.SetBool("Fade", true);
            //debug.text = "2";
        }
        else if(currentMoves == 26)
        {
            currentScore = 1;
            starTwoAnimator.SetBool("Fade", true);
            //debug.text = "1";
        }
    }
}
