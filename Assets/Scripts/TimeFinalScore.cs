using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeFinalScore : MonoBehaviour
{
    public int Score;
    public GameObject starOne, starTwo, starThree;
    public Text endText;
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
                endText.text = "3 Stars!";
                starOne.SetActive(true);
                starTwo.SetActive(true);
                starThree.SetActive(true);
                break;
            case 2:
                //Show 2 stars.
                endText.text = "2 Stars!";
                starOne.SetActive(true);
                starTwo.SetActive(true);
                break;
            case 1:
                //Show 1 star.
                endText.text = "1 Star!";
                starOne.SetActive(true);
                break;
        }
    }
}
