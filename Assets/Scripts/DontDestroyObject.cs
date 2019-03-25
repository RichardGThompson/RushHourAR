using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DontDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] dontDestroyArray = GameObject.FindGameObjectsWithTag("PositionTracker");
        
        if(dontDestroyArray.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


}