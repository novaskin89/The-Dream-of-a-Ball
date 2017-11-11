using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour

   
{
    public GameObject Gate1;
    public PlayerController playercontroller;
    private Animator _animator;


    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontroller.count >= 8)
        {

        }
    }



}

