using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTracker : MonoBehaviour
{
    public int currentMoves;
    public Text moveCountText;
    public void updateMoveCount(int moveCount)
    {
        currentMoves += moveCount;
        moveCountText.text = currentMoves.ToString();
    }
}
