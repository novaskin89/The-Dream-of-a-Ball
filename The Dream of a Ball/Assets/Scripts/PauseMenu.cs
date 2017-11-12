using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseCanvas;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseCanvas.gameObject.activeInHierarchy == false)
            {
                pauseCanvas.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
           else
            {
                pauseCanvas.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}
