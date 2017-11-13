using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public GameObject Light;
    public Transform dropdown;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dropdown.GetComponent<Dropdown>().value == 0)
        {
            Light.GetComponent<Light>().shadows = LightShadows.Soft;
        }

        if (dropdown.GetComponent<Dropdown>().value == 1)
        {
            Light.GetComponent<Light>().shadows = LightShadows.Hard;
        }

        if (dropdown.GetComponent<Dropdown>().value == 2)
        {
            Light.GetComponent<Light>().shadows = LightShadows.None;
        }
    }
}
