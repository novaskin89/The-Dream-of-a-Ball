using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenGate : MonoBehaviour
{
    public int target;
    public Transform OpenedClosedPosition;
    public float speed;
    public GameObject text;
    public GameObject image;
    public bool trigger = false;
    public bool trigger2 = false;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.playerController.count >= target)
        {
            OpenDoor();
            text.gameObject.SetActive(false);
            image.gameObject.SetActive(false);
        }

        if (trigger == true)
        {
            OpenDoor2();
        }
    }

    void OpenDoor()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, OpenedClosedPosition.position, step);
    }

    void OpenDoor2()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, OpenedClosedPosition.position, step);
    }
}

