using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFinalScore : MonoBehaviour
{
    public int Score;
    public GameObject starOne, starTwo, starThree;
    private int finalScore;
    private GameObject gameController;

    public void Start()
    {
        gameController = GameObject.Find("GameController");
        finalScore = gameController.GetComponent<TimeRewards>().currentScore;
        switch (finalScore)
        {
            case 3:
                //Show all three stars.
                starOne.SetActive(true);
                starTwo.SetActive(true);
                starThree.SetActive(true);
                break;
            case 2:
                //Show 2 stars.
                starOne.SetActive(true);
                starTwo.SetActive(true);
                break;
            case 1:
                //Show 1 star.
                starOne.SetActive(true);
                break;
        }
    }
}
