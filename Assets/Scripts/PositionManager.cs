using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PositionManager : MonoBehaviour
{
    static public bool firstRun = true;
    static public Vector3[] currentPositions;
    public string[] carNames;
    public Vector3[] startingPositions;
    public GameObject[] cars;


    private void Start()
    {
        Debug.Log("Started!");
        currentPositions = new Vector3[cars.Length];
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i] = GameObject.Find("GameController").GetComponent<CarsInScene>().carList[i];
        }

        //If it is the first run, then set all of the cars in their starting position.
        if (firstRun)
        {
            for(int i = 0; i < cars.Length; i++)
            {
                cars[i].transform.position = startingPositions[i];
            }
            firstRun = false;
        }
        else
        {
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i].transform.position = currentPositions[i];
            }
        }
    }

    private void Update()
    {
        if(cars[0] == null)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                cars[i] = GameObject.Find("GameController").GetComponent<CarsInScene>().carList[i];
                cars[i].transform.position = currentPositions[i];
            }
        }
        
        for(int i = 0; i < cars.Length; i++)
        {
            currentPositions[i] = cars[i].transform.position;
        }
        
    }
}
