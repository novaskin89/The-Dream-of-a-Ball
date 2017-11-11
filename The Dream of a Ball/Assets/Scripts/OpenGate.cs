using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenGate : MonoBehaviour


{

    public PlayerController playercontroller;
    private Animator animator;
    private PlayableDirector playableDirector;
    // Use this for initialization
    void Start()
    {

        animator = GetComponent<Animator>();
        playableDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontroller.count >= 1)
        {

            playableDirector.Play();
        }
    }



}

