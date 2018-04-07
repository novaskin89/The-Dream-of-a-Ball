using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectBecomeRigid : MonoBehaviour
{
    public Rigidbody rb;
    public bool boss1isdied;

    // Use this for initialization
    void Start()
    {
        boss1isdied = false;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();  // in awake lo script ottiene il rigidbody della pallina
    }

    // Update is called once per frame


    void Update()
    {
        if (Boss.instance.BossHealth == 0)

        {
            boss1isdied = true;

        }

        if (boss1isdied == true)

        {
            ClearHealthUp();
        }
    }

    void ClearHealthUp ()
    {
        if (boss1isdied == true)
        {
            Destroy(gameObject);
            //yield return new WaitForSeconds(1);  
            boss1isdied = false;
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossPlane")
        {
            rb.useGravity = false;

            //// find child:
            //Transform childOfObject = gameObject.transform.GetChild(0);
            //// find parent of child:
            //Transform parentOfObject = gameObject.transform.parent;
            //// assign child to parent
            //childOfObject.parent = parentOfObject;
        }
    }
}

//GetComponentInParent<Rigidbody>().useGravity = true;
//        GetComponentInParent<Rigidbody>().isKinematic = false;
//        Destroy(this.gameObject, 2f);