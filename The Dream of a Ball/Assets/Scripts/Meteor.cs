using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public ParticleSystem fireExplosion;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossPlane")
        {
            StartCoroutine("Explode");
        }

        if (other.tag == "DestroyMeteor")
        {
            StartCoroutine("Explode");
            Destroy(gameObject);
        }
    }

    IEnumerator Explode()
    {
        fireExplosion.Play();
        fireExplosion.gameObject.transform.parent = null;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

        // find child:
        //Transform childOfObject = gameObject.transform.GetChild(0);
        // find parent of child:
        //Transform parentOfObject = gameObject.transform.parent;
        // assign child to parent
        //childOfObject.parent = parentOfObject;
    }
}
