using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalReached : MonoBehaviour
{
    public GameObject Caranimator;
    public GameObject ResultsScreen;
    // Start is called before the first frame update
    void Start()
    {
        ResultsScreen = GameObject.FindGameObjectWithTag("ResultsScreen");
        ResultsScreen.SetActive(false);
        //ResultsScreen = GameObject.Find("ResultsScreen");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray raycast = new Ray(transform.position, transform.right);
        if (Physics.Raycast(raycast, out hit, 1))
        {
            Debug.DrawRay(transform.position, transform.right, Color.red);
            if (hit.collider != null)
            {
                Debug.Log("Not null");
                if (hit.collider.tag == "Goal")
                {
                    //Debug.Log("hit goal");
                    ResultsScreen.SetActive(true);
                    Caranimator.gameObject.SetActive(true);
                    Caranimator.GetComponent<Animator>().SetBool("Victory", true);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
