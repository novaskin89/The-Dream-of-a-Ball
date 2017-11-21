using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour

{
    public IntroloopAudio mainMenuIntroLoop;
    public bool stopPlay = false;


    // Use this for initialization
    void Start()
    {
        IntroloopPlayer.Instance.Play(mainMenuIntroLoop);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopPlay == true)
        {
            IntroloopPlayer.Instance.Stop();
        }
    }

    public void NewGameButton(string Level1)
    {
        PlayerPrefs.SetInt("PickUpCollected", 0);
        PlayerPrefs.SetInt("livesLeft", 1);
        PlayerPrefs.SetInt("healthLeft", 3);
        SceneManager.LoadScene(Level1);
        stopPlay = true;
    }

    public void ContinueButton(string Level1)
    {
        SceneManager.LoadScene(Level1);
        stopPlay = true;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
