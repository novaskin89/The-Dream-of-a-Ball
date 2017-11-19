using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndQuit : MonoBehaviour

{
    public PlayerController playerController;
    int pickupCollected;
    // Use this for initialization
    void Start()
    {
        Debug.Log("SaveAndQuitPickUpCollected " + PlayerPrefs.GetInt("PickUpCollected"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit(bool Quit)
    {
        if (Quit)
        {
            PlayerPrefs.SetInt("PickUpCollected", playerController.count);
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
