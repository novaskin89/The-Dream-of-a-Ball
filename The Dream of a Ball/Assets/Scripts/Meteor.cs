using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossPlane")
        {
            Destroy(gameObject);
        }
    }
}
