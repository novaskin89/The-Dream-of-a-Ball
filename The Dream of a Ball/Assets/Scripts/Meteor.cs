using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject explosionRadius;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossPlane")
        {
            explosionRadius.SetActive(true);
            Destroy(gameObject);
            Destroy(explosionRadius);

        }
    }
}
