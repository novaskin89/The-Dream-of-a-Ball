using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseActivation : MonoBehaviour
{
    // Use this for initialization
    void Awake()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
        Screen.lockCursor = true;
        StartCoroutine(StopMouse());
    }

    IEnumerator StopMouse()
    {

        yield return new WaitForSeconds(3);
        Cursor.visible = true;
        Screen.lockCursor = false;
    }
}
