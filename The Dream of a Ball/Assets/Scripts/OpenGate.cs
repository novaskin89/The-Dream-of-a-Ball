using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{

    public float speed = 1.87f;
    private int count;

    // Use this for initialization
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //(Vector3.up * speed * Time.deltaTime);
       // transform.Translate(0, 0, 0);
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            Debug.Log ("PickUp "+ count);
        }
    }
    void SetCountText()

    {

        if (count >= 2)
        {
            transform.Translate(0, -Time.deltaTime, 0, Space.World);
            //  Vector3.up (3 * Time.deltaTime);
        }
    }
}

