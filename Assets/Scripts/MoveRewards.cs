using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRewards : MonoBehaviour
{
    private int[] rewardValues;
    public int currentScore;
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
        rewardValues[0] = threeStar + 1;
        rewardValues[1] = twoStar + 1;
        currentMoves = 0;
        currentScore = 3;
    }


    void Update()
    {
        currentMoves = GetComponent<MoveTracker>().currentMoves;
        if(currentMoves == rewardValues[0])
        {
            currentScore = 2;
            starThree.SetActive(false);
        }
        else if(currentMoves == rewardValues[1])
        {
            currentScore = 1;
            starTwo.SetActive(false);
        }
    }
}
