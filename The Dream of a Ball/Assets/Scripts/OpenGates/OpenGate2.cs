using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenGate2 : MonoBehaviour
{
    public bool trigger = false;
    public Transform OpenedClosedPosition;
    public Transform OpenedClosedPosition2;
    public float speed;
    public GameObject gateA;
    public GameObject meteorSpawner;
    public GameObject preBossArea;
    public GameObject MovingFan;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == true)
        {
            OpenDoor();
        }
    }
    void OpenDoor()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, OpenedClosedPosition.position, step);
        gateA.transform.position = Vector3.MoveTowards(transform.position, OpenedClosedPosition.position, step);
        preBossArea.SetActive(true);
        MovingFan.SetActive(true);
    }

}
