using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enablemouse : MonoBehaviour
{
    // Use this for initialization
    void Awake()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        StopMouse();
    }

    IEnumerator StopMouse()
    {

        yield return new WaitForSeconds(3);
        Cursor.visible = true;
    }
}

