using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndQuit : MonoBehaviour

{
    public PlayerController playerController;
    int pickupCollected;
    int LivesLeft;
    int healtLeft;
    int lives;
    // Use this for initialization
    void Start()
    {
       
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
            PlayerPrefs.SetInt("livesLeft", playerController.lives);
            PlayerPrefs.SetInt("healthLeft", playerController.health);
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
