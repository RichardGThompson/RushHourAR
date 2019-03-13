using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DPadMovement : MonoBehaviour
{
    Behaviour halo;
    private GameObject selectedObject, previousObject;
    private Button upButton, downButton, rightButton, leftButton, undoButton;

    private float carSize;
    private bool undoneAlready = false;
    private bool firstTurn = true;
    private int currentObjectMoveCount, previousAction, previousMoveCount, moveCount = 0;
    Material m_Mat;

    void ButtonPressed(int action)
    {
        if(action == 4)
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
                        if (selectedObject != previousObject)
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

        if(selectedObject.tag == "Moveable2" || selectedObject.tag == "Moveable3")
        {
            if (selectedObject.tag == "Moveable2")
            {
                carSize = 1.01f;
                
            }
            else if(selectedObject.tag == "Moveable3")
            {
                carSize = 1.51f;
            }
            switch (action)
            {
                case 0:
                    if (selectedObject.transform.rotation.eulerAngles.y == 0)
                    {
                        //Move it up if the object is facing up-down.
                        if(selectedObject.GetComponent<CarDetection>().raycastResult(1.0f, carSize) == false)
                        {
                            selectedObject.transform.Translate(1, 0, 0);
                        }
                        currentObjectMoveCount++;
                        previousAction = 0;
                    }
                    break;
                case 1:
                    if (selectedObject.transform.rotation.eulerAngles.y == 0)
                    {
                        //Move it down if the object is facing up-down.
                        if (selectedObject.GetComponent<CarDetection>().raycastResult(-1.0f, carSize) == false)
                        {
                            selectedObject.transform.Translate(-1, 0, 0);
                        }
                        currentObjectMoveCount++;
                        previousAction = 1;
                    }
                    break;
                case 2:
                    if (selectedObject.transform.rotation.eulerAngles.y == 90 || selectedObject.transform.rotation.eulerAngles.y == 270)
                    {
                        //Move it right if the object is facing left-right.
                        if (selectedObject.GetComponent<CarDetection>().raycastResult(1.0f, carSize) == false)
                        {
                            selectedObject.transform.Translate(1, 0, 0);
                        }
                        currentObjectMoveCount++;
                        previousAction = 0;
                    }
                    break;
                case 3:
                    if (selectedObject.transform.rotation.eulerAngles.y == 90 || selectedObject.transform.rotation.eulerAngles.y == 270)
                    {
                        //Move it left if the object is facing left-right.
                        if (selectedObject.GetComponent<CarDetection>().raycastResult(-1.0f, carSize) == false)
                        {
                            selectedObject.transform.Translate(-1, 0, 0);
                        }
                        currentObjectMoveCount++;
                        previousAction = 1;
                    }
                    break;
            }
        }   
    }
    
    void selectCar()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began && UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (selectedObject != hit.transform.gameObject)
                    {
                        undoneAlready = false;
                        currentObjectMoveCount = 0;
                    }
                    switch (firstTurn)
                    {
                        case false:
                            previousObject = selectedObject;
                            selectedObject = hit.transform.gameObject;
                            previousObject.GetComponent<Outline>().enabled = false;
                            selectedObject.GetComponent<Outline>().enabled = true;
                            
                            break;
                        case true:
                            selectedObject = hit.transform.gameObject;
                            previousObject = selectedObject;
                            firstTurn = false;
                            break;
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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
        selectCar();
    }
}
