using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Music : MonoBehaviour
{

    public IntroloopAudio level1IntroLoop;
    public bool stopPlay = false;
    // Use this for initialization
    void Start ()
    {
        IntroloopPlayer.Instance.Play(level1IntroLoop);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
