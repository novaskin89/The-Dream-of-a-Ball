using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlayer : MonoBehaviour
{
    public AudioClip soundToPLay;
    public float Volume;
    AudioSource _audio;
    public bool alreadyPlayed = false;
    public PlayerController playercontroller;

    // Use this for initialization
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnTriggerEnter()
    {

        if (!alreadyPlayed)
        {
            _audio.PlayOneShot(soundToPLay, Volume);
            alreadyPlayed = true;
            alreadyPlayed = false;
        }
    }
 
}