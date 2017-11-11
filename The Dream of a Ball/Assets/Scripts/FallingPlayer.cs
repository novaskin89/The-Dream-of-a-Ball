using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlayer : MonoBehaviour
{
    bool hasFallen = false;
    public AudioClip soundToPLay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    public PlayerController playercontroller;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if
        //{

        //}
    }
    void OnTriggerEnter()
    {

        if (!alreadyPlayed)
        {
            audio.PlayOneShot(soundToPLay, Volume);
            alreadyPlayed = true;
            alreadyPlayed = false;
        }
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log ("caduto");
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        AudioSource audio = GetComponent<AudioSource>();
    //        audio.Play();
    //        audio.PlayDelayed(44100);
    //    }
    //}
}