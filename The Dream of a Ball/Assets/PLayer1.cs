using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer1 : MonoBehaviour
{
    public int vita;
    public float pos;
    public bool gameover;


    // Use this for initialization
    void Start()
    {
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (vita < 0)

        {
            gameover = true;
        }
    }

}