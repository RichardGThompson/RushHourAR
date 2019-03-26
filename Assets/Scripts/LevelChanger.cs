using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator levelChange;
    private int levelToLoad;

    public void fadeToLevel(int levelID)
    {
        levelToLoad = levelID;
        levelChange.SetTrigger("FadeOut");

    }

    public void fadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
