using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionManager : MonoBehaviour
{
    private GameObject[] carPositions;
    private GameObject[] tempPositions;
    public Vector3[] carVector;

    private void Start()
    {
        Debug.Log("Testing!");
        carPositions = GameObject.FindGameObjectsWithTag("Moveable2");
        tempPositions = GameObject.FindGameObjectsWithTag("Moveable3");
        carPositions = carPositions.Concat(tempPositions).ToArray();
        
        Debug.Log(carPositions[0]);
    }
}
