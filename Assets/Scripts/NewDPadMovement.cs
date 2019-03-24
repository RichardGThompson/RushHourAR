using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDPadMovement : MonoBehaviour
{
    //Private Variables:
    private GameObject selectedObject, previousObject, touchedObject;
    private Button upButton, downButton, rightButton, leftButton, undoButton;
    private RaycastHit hit;
    private float carSize;
    private bool undoneAlready, firstTurn, carRotation;
    private int currentObjectMoveCount, previousAction, previousMoveCount, moveCount = 0;


    //Public Variables:

        
    void ButtonPressed(int buttonID)
    {
        if(buttonID == 4)
        {
            if(undoneAlready == false && currentObjectMoveCount != 0)
            {
                switch (previousAction)
                {
                    case 0:
                        if(selectedObject != previousObject)
                        {
                            selectedObject.transform.Translate(-1, 0, 0);
                        }
                        else
                        {
                            previousObject.transform.Translate(-1, 0, 0);
                        }
                        undoneAlready = true;
                        previousMoveCount = moveCount;
                        moveCount--;
                        break;
                    case 1:
                        if(selectedObject != previousObject)
                        {
                            selectedObject.transform.Translate(1, 0, 0);
                        }
                        else
                        {
                            previousObject.transform.Translate(1, 0, 0);
                        }
                        undoneAlready = true;
                        previousMoveCount = moveCount;
                        moveCount--;
                        break;
                }
            }
        }
        //Checks to see what size the car is. 
        if (selectedObject.tag == "Moveable2")
        {
            //If it has a size of Moveable2 then it is 2 unit, meaning you need a raycast of 1.1 units.
            carSize = 1.1f;
        }
        else if (selectedObject.tag == "Moveable3")
        {
            //Same thing for Moveable3 but just bigger.
            carSize = 1.6f;
        }

        switch (buttonID)
        {

            //Up.
            case 0:
                //Checks to see if there is an object impeding it's movement and if there is not then the car will move.
                if (!(selectedObject.GetComponent<CarDetection>().raycastResult(1.0f, carSize)))
                {
                    selectedObject.transform.Translate(1, 0, 0);
                    previousAction = 0;
                }
                
                break;
            //Down.
            case 1:
                if (!(selectedObject.GetComponent<CarDetection>().raycastResult(-1.0f, carSize)))
                {
                    selectedObject.transform.Translate(-1, 0, 0);
                    previousAction = 1;
                }
                break;
            //Right.
            case 2:
                if (selectedObject.transform.rotation.eulerAngles.y == 90 || selectedObject.transform.rotation.eulerAngles.y == 270)
                {
                    selectedObject.transform.Translate(1, 0, 0);
                    previousAction = 2;
                }
                break;
            //Left.
            case 3:
                if (selectedObject.transform.rotation.eulerAngles.y == 90 || selectedObject.transform.rotation.eulerAngles.y == 270)
                {
                    selectedObject.transform.Translate(-1, 0, 0);
                    previousAction = 3;
                }
                break;
               
       }
    }
    
    void SelectCar()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                touchedObject = hit.transform.gameObject;
                if (touchedObject.tag == "Moveable2" || touchedObject.tag == "Moveable3")
                {
                    if(selectedObject != touchedObject)
                    {
                        undoneAlready = false;
                        currentObjectMoveCount = 0;
                    }
                    switch (firstTurn)
                    {
                        case false:
                            previousObject = selectedObject;
                            selectedObject = touchedObject;
                            
                            break;
                        case true:
                            selectedObject = touchedObject;
                            previousObject = selectedObject;
                            firstTurn = false;
                            break;
                    }
                }
            }
        }
    }

    void SetCarSize(GameObject carInfo)
    {
        if (carInfo.tag == "Moveable2")
        {
            carSize = 1.1f;
        }
        else if(carInfo.tag == "Moveable3")
        {
            carSize = 1.6f;
        }
    }


    void Start()
    {
        //Setting variables as they are needed at start.
        undoneAlready = false;
        firstTurn = false;

        //Decalring all of the buttons.
        upButton = GameObject.Find("UpButton").GetComponent<Button>();
        downButton = GameObject.Find("DownButton").GetComponent<Button>();
        rightButton = GameObject.Find("RightButton").GetComponent<Button>();
        leftButton = GameObject.Find("LeftButton").GetComponent<Button>();
        undoButton = GameObject.Find("UndoButton").GetComponent<Button>();

        upButton.onClick.AddListener(() => ButtonPressed(0));
        downButton.onClick.AddListener(() => ButtonPressed(1));
        rightButton.onClick.AddListener(() => ButtonPressed(2));
        leftButton.onClick.AddListener(() => ButtonPressed(3));
        undoButton.onClick.AddListener(() => ButtonPressed(4));
    }

    // Update is called once per frame
    void Update()
    {
        SelectCar();
    }
}
