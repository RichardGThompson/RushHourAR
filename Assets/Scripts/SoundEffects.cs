using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip aClip;
    public AudioSource aSource;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.clip = aClip;
       
    }

    // Update is called once per frame
    void Update()
    {
        aSource.Play();
    }
}
