using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolumeLevel : MonoBehaviour
{
    public float volume;
    GameObject musicSourceScene;
    //public GameObject musicSourcePrefab;
    public Slider musicslider;
    public GameObject[] musicsourcearray;
    public GameObject[] OptionsMenu;
    GameObject[] MusicController;
    // Start is called before the first frame update

    void Start()
    {
        musicSourceScene = GameObject.FindGameObjectWithTag("MusicSource");
        volume = musicslider.value;
        // musicSourcePrefab.GetComponent<AudioSource>().volume = volume;
    }

    // Update is called once per frame
    void Update()
    {
        musicSourceScene.GetComponent<AudioSource>().volume = volume;
        //musicSourcePrefab.GetComponent<AudioSource>().volume = volume;
    }
    public void SetAudioLevel()
    {
        volume = musicslider.value;
    }


}
