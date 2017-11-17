using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public PlayerController playercontroller;
    public Transform gameOverCanvas;
    public Transform gameOverMenu1;
    //public Transform GameOverMenu;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverCanvas.gameObject.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            gameOverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (playercontroller.lives == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverCanvas.gameObject.SetActive(true);
        gameOverMenu1.gameObject.SetActive(true);
    } 

    public void Exit(string MainMenu)
    {
        SceneManager.LoadScene("MainMenu");
    }

    // all below is meant to restart level
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadPreviousScene()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else RestartScene();
    }

    public void LoadNextScene()
    {
        if ((SceneManager.GetActiveScene().buildIndex + 1) < SceneManager.sceneCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else RestartScene();
    }
}
