using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIfTargetActive : MonoBehaviour
{
    public GameObject ImageTarget;
    //public Text debugText;
    // Update is called once per frame
    void Update()
    {
        trackerFound();
    }
    public bool trackerFound()
    {
        if (ImageTarget.GetComponent<DefaultTrackableEventHandler>().trackerFound == true)
        {
            //debugText.text = "TrackerFound!";
            return true;
        }
        else
        {
            //debugText.text = "TrackerLost!";
            return false;
        }
    }
}
