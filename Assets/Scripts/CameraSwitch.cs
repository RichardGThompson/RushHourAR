using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    private Button cameraButton;
    private Camera arCamera, topDownCamera;
    private bool arEnabled = false;
    
    void changeCamera()
    {
        if(arCamera.enabled == true)
        {
            Debug.Log("Switch To Top-Down Camera.");
            arCamera.enabled = false;
            topDownCamera.enabled = true;
            arCamera.tag = "3DCamera";
            topDownCamera.tag = "MainCamera";
        }
        else if (topDownCamera.enabled == true)
        {
            Debug.Log("Switch to AR Camera.");
            arCamera.enabled = true;
            topDownCamera.enabled = false;
            arCamera.tag = "MainCamera";
            topDownCamera.tag = "3DCamera";
        }
    }



    private void Start()
    {
        cameraButton = GameObject.Find("CameraButton").GetComponent<Button>();
        arCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
        topDownCamera = GameObject.Find("TopDownCamera").GetComponent<Camera>();
        Debug.Log("Init.");
        arCamera.enabled = true;
        topDownCamera.enabled = false;
        cameraButton.onClick.AddListener(() => changeCamera());
    }
}
