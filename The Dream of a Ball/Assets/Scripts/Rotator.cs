using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rotator : MonoBehaviour
{
    public float Y;
    public float Z;
    public float X;
    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {  
     transform.Rotate(new Vector3(Y, Z, X) * Time.deltaTime);
    }
}
