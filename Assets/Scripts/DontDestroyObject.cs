using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DontDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] dontDestroyArray = GameObject.FindGameObjectsWithTag(gameObject.tag);
        
        if(dontDestroyArray.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


}