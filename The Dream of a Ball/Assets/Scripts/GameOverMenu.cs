using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public PlayerController playercontroller;
    public Level1Music level1Music;
    public IntroloopAudio level1IntroLoop;
    public Transform gameOverCanvas;
    public Transform gameOverMenu1;
    public bool stopToPlay = false;
    //public Transform GameOverMenu;
    // Use this for initialization
    void Start()
    {
        IntroloopPlayer.Instance.Play(level1IntroLoop);  // quando il gioco inizia parte la musica
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverCanvas.gameObject.activeInHierarchy == true)
        {
            Time.timeScale = 0;
        }

        if (playercontroller.lives == 0)
        {
            GameOver();
        }

        if (stopToPlay == true)
        {
            //se il bool diventa vero la musica si ferma (cioè quando si chiama il restart game dal 
            //gameover menu, questo bool è chiamato dallo script gameovermenu
            IntroloopPlayer.Instance.Stop();
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
    public void RestartScene()    // se il player fa restart game voglio che la musica si ferma
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        stopToPlay = true;  //quindi metto il bool dello script della musica su vero in modo che la fermi
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
