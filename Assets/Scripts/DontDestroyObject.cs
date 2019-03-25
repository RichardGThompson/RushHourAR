using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DontDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] moveableTwos = GameObject.FindGameObjectsWithTag("Moveable2");
        GameObject[] moveableThrees = GameObject.FindGameObjectsWithTag("Moveable3");
        GameObject[] finalArray = moveableTwos.Concat(moveableThrees).ToArray();
        if(finalArray.Length > 3)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


}