using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("ButtonManagerPickUpCollected " + PlayerPrefs.GetInt("PickUpCollected"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewGameButton(string Level1)
    {
        PlayerPrefs.SetInt("PickUpCollected", 0);
        SceneManager.LoadScene(Level1);
    }

    public void ContinueButton(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
