using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public ParticleSystem fireExplosion;
    public GameObject fireball;
    public Rigidbody rb;
    public Renderer rend;
    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossPlane")
        {
            StartCoroutine("Explode");
        }

        //if (other.tag == "DestroyMeteor")
        //{
        //    StartCoroutine("Explode");
        //    Destroy(gameObject);
        //}
    }

    IEnumerator Explode()
    {
        rend.enabled = false;
        rb.isKinematic = true;
        fireExplosion.Play();
        //fireExplosion.gameObject.transform.parent = null;
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);

        // find child:
        //Transform childOfObject = gameObject.transform.GetChild(0);
        // find parent of child:
        //Transform parentOfObject = gameObject.transform.parent;
        // assign child to parent
        //childOfObject.parent = parentOfObject;
    }
}
