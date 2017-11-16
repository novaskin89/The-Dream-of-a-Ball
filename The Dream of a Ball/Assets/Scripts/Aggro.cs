using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggro : MonoBehaviour
{

    public float range = 7f;
    public Transform target;
    public float movespeed = 5f;




    void Start() // Use this for initialization
    {
        target = GameObject.FindWithTag("Player").transform; //target the player
    }

    void Update() // Update is called once per frame
    {
        float distanceAttuale = Vector3.Distance(target.position, transform.position);

        if (distanceAttuale <= range)
        {

            transform.LookAt(target.transform);

            transform.position += transform.forward * movespeed * Time.deltaTime;

        }

    }
}