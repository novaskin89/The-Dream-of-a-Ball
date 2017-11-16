using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
    private EnumExample enumExample;
   

    // Use this for initialization
    void Awake()
    {
        enumExample = GetComponent<EnumExample>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enumExample.currentEnemyState = (EnumExample.EnemyState)Random.Range(0, 3);
        }
    }
}
