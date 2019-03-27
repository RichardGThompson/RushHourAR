using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using Vuforia;


//NOTE: Need to make the program only look for the vehicle gameObjects when the tracking card is in sight.

public class PositionManager : MonoBehaviour
{
    private GameObject gameController;
    static public bool firstRun = true;
    static public Vector3[] currentPositions;
    public string sceneName;
    Scene currScene;
    public string[] carNames;
    public Vector3[] startingPositions;
    public GameObject[] cars;
    public Vector3[] carPostions;
    private bool arLevel = false;

    //Testing Variables:
    public bool nameTested = false;
    private string arString = "AR";

    private void Start()
    {
        gameController = GameObject.Find("GameController");
        //Sets the length of the currentPositions array to the lengeth of the cars array.
        currentPositions = new Vector3[cars.Length];
        carPostions = new Vector3[cars.Length];
        
        //Sets the cars in the array to their respective gameobject in the gamecontroller.
        for (int i = 0; i < cars.Length; i++)
        {
            cars[i] = GameObject.Find("GameController").GetComponent<CarsInScene>().carList[i];
        }

        //If it is the first run, then set all of the cars in their starting position.
        if (firstRun)
        {
            //Sets all of the positions of the gameobjects in the cars array to their respective startingPositions.
            for(int i = 0; i < cars.Length; i++)
            {
                cars[i].transform.position = startingPositions[i];
            }
            //Sets the first run bool to false.
            firstRun = false;
        }
    }

    private void Update()
    {
        currScene = SceneManager.GetActiveScene();
        sceneName = currScene.name;
        //Checks to see if the name has not been checked yet, check if the current level is an AR level or not and set the bool accordingly.
        if (sceneName.Contains(arString))
        {
            arLevel = true;
        }
        else
        {
            arLevel = false;
        }
        

        //If the first car in the cars array is null, this means that the scene has been changed and things need to be updated.
        //The first update that needs to be made is that the gameobjects in the cars array need to be reassigned, they will be assigned the same way as they initally were, by looking at the array within the gamecontroller.
        //Once that is done, they will be set to the the current position.
        if(cars[0] == null)
        {
            gameController = GameObject.Find("GameController");
            Debug.Log(gameController.name);
            Debug.Log(arLevel);
            //If it is an AR level, check to see if the image target is found.
            if (arLevel == true)
            {
                if(gameController.GetComponent<CheckIfTargetActive>().trackerFound() == true)
                {
                    for (int i = 0; i < cars.Length; i++)
                    {
                        cars[i] = GameObject.Find("GameController").GetComponent<CarsInScene>().carList[i];
                        cars[i].transform.position = currentPositions[i];
                    }
                    nameTested = false;
                }
            }
            else if(arLevel == false)
            {
                for (int i = 0; i < cars.Length; i++)
                {
                    cars[i] = GameObject.Find("GameController").GetComponent<CarsInScene>().carList[i];
                    cars[i].transform.position = currentPositions[i];
                }
                nameTested = false;
            }
        }
        //Updates the current position for all of the objects each frame.
        for(int i = 0; i < cars.Length; i++)
        {
            currentPositions[i] = cars[i].transform.position;
            carPostions[i] = cars[i].transform.position;
        }
        
    }
}
