using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    public float GravitationalPull;
    public float distance;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float distance = .sqrMagnitude * DistanceMultiplier + 1;
    }

    void OnTriggerEnter(Collider other )
    {
        if (other.gameObject.CompareTag("Player"))

        {
            Vector3 direction = transform.position - PlayerController.playerController.rb.transform.position;
            PlayerController.playerController.rb.AddForce(direction.normalized * (GravitationalPull / distance) * PlayerController.playerController.rb.mass * Time.fixedDeltaTime);
        }


    }


}
