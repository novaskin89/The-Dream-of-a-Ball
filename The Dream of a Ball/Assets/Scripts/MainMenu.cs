using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour

{
    public string nuovoNome = "davide";
    public GameObject titolo;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        titolo.GetComponent<Text>().text = nuovoNome;
    }
    public void StartGame(string Level1)
    {

        SceneManager.LoadScene(Level1);
    }
}
