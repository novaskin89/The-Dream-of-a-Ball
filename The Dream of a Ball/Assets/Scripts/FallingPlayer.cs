using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlayer : MonoBehaviour
{
    bool hasFallen = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log ("caduto");
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.PlayDelayed(44100);
        }
    }
}