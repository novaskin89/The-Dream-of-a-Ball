using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Music : MonoBehaviour
{

    public IntroloopAudio level1IntroLoop;
    public IntroloopAudio bossIntroLoop;
    public GameObject bossTrigger;
    public bool stopPlay = false;
    public bool bossMusicTrigger = false;
    // Use this for initialization
    void Start()
    {
        IntroloopPlayer.Instance.Play(level1IntroLoop);  // quando il gioco inizia parte la musica
    }

    // Update is called once per frame
    void Update()
    {
        //if (stopPlay == true)
        //{
        //    //se il bool diventa vero la musica si ferma (cioè quando si chiama il restart game dal 
        //    //gameover menu, questo bool è chiamato dallo script gameovermenu
        //    IntroloopPlayer.Instance.StopFade();

        //}

        if (bossMusicTrigger == true)
        {
            BossMusic();
            bossMusicTrigger = false;
        }

     
        //if (bossTrigger == true)
        //{
        //    //    BossMusic();
        //    //}

        //    if (Input.GetKeyDown(KeyCode.M))
        //    {
        //        IntroloopPlayer.Instance.Play(bossIntroLoop);
        //    }

        //    if (Input.GetKeyDown(KeyCode.N))
        //    {
        //        IntroloopPlayer.Instance.Stop();
        //    }
        //}


    }
    public void BossMusic()
    {
        IntroloopPlayer.Instance.Play(bossIntroLoop);  // quando il gioco inizia parte la musica
    }
}
