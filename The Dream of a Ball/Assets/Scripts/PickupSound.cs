using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSound : MonoBehaviour
{
    //public AudioSource tickSource;

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
}