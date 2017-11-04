using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform RespawnPoint;



    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Player.transform.position = RespawnPoint.transform.position;
    }

}
