using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMeshes : MonoBehaviour
{
    private Renderer meshRend;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Mesh Disabled");
        meshRend = GetComponent<Renderer>();
        meshRend.enabled = false;
    }
}
