using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    private Button cameraButton;
    private Camera ARCamera, TopDownCamera;
    void changeCamera()
    {

    }

    private void Start()
    {
        cameraButton = GameObject.Find("CameraButton").GetComponent<Button>();
        ARCamera = GameObject.Find("")
        cameraButton.onClick.AddListener(() => changeCamera());
    }
}
