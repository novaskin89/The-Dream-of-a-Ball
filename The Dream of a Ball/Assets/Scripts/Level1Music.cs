using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Music : MonoBehaviour
{

    public IntroloopAudio level1IntroLoop;
    public IntroloopAudio bossIntroLoop;
    public GameObject BossTrigger;
    public bool stopPlay = false;
    public bool bossTrigger = false;
    // Use this for initialization
    void Start()
    {
        IntroloopPlayer.Instance.Play(level1IntroLoop);  // quando il gioco inizia parte la musica
    }

    // Update is called once per frame
    void Update()
    {
        if (stopPlay == true)
        {
            //se il bool diventa vero la musica si ferma (cioè quando si chiama il restart game dal 
            //gameover menu, questo bool è chiamato dallo script gameovermenu
            IntroloopPlayer.Instance.Stop();

        }

        if (bossTrigger == true)
        {
            IntroloopPlayer.Instance.Stop();
            IntroloopPlayer.Instance.Play(bossIntroLoop);  // quando il gioco inizia parte la musica
        }
    }
}
