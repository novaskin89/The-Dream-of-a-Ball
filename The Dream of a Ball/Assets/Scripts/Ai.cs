using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{

    public int decision;


	// Use this for initialization
	void Start ()
    {
        switch (decision)
        {
            case 1:
                //Debug.Log("Decisione 1");
                break;

            case 5:
               // Debug.Log("Decisione 5");
                break;

            case 22:
                //Debug.Log("Decisione 22");
                break;

            case 556:
               // Debug.Log("Decisione 556");
                break;
                
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
