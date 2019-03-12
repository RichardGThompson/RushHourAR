using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetection : MonoBehaviour
{
    private float raycastDistance;
    public bool raycastResult(float direction, float carSize)
    {
        raycastDistance = carSize;
        RaycastHit hit;

        Ray raycast = new Ray(this.transform.position, direction * transform.right);
        if(Physics.Raycast(raycast, out hit, raycastDistance))
        {
            if(hit.transform.gameObject.tag == "Goal")
            {
                return false;
            }
            else
            {
                Debug.Log("Collision Detected!");
                return true;
            }
        }

        return false;
    }
}
