using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassicEndScore : MonoBehaviour
{
    public int Score;
    public GameObject starOne, starTwo, starThree;
    public Text endText;
    private int finalScore;
    private GameObject gameController;

    public void Start()
    {
        gameController = GameObject.Find("GameController");
        finalScore = gameController.GetComponent<MoveRewards>().currentScore;
        switch (finalScore)
        {
            case 3:
                //Show all three stars.
                starOne.SetActive(true);
                starTwo.SetActive(true);
                starThree.SetActive(true);
                endText.text = "3 Stars!";
                break;
            case 2:
                //Show 2 stars.
                starOne.SetActive(true);
                starTwo.SetActive(true);
                endText.text = "3 Stars!";
                break;
            case 1:
                //Show 1 star.
                starOne.SetActive(true);
                endText.text = "3 Stars!";
                break;
        }
    }
}
