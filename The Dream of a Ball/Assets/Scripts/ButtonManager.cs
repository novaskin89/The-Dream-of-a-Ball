using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGameButton(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
