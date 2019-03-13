using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RevealMenu : MonoBehaviour
{
    public RectTransform menu;
    public RectTransform menubutton;
    public Animator menuanimation;
    bool show = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(show)
        {
            menu.anchoredPosition = menubutton.anchoredPosition * Time.deltaTime;
        }
    }
    public void ShowMenu()
    {
        menuanimation.SetTrigger("RevealMenu");
    }
    public void RetractMenu()
    {

        menuanimation.SetTrigger("RetractMenu");
    }
}
