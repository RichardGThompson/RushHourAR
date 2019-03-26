using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayCastTest : MonoBehaviour
{
    private bool spinObj;
    private RaycastHit hit;
    private GameObject hitObject;
    // Start is called before the first frame update
    void Start()
    {
        spinObj = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if(Physics.Raycast(ray, out hit))
            {
                hitObject = hit.transform.gameObject;
                if(hitObject.tag == "Moveable2" || hitObject.tag == "Moveable3")
                {
                    hitObject.transform.Rotate(Vector3.up, 50.0f * Time.deltaTime);
                }

                
            }
        }
    }
}
