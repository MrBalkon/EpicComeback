using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
   internal static bool MusicState;
    public AudioSource music;
    public Sprite musicOf;
    public Sprite musicOn;
    private Sprite sr;
    private void Start()
    {
        MusicState = true;
        music = GameObject.FindGameObjectWithTag("MainMusic").GetComponent<AudioSource>();
    }
    public void MusicStateControll()
    {
        MusicState = !MusicState;


        if (!MusicState)
        {
            music.Pause();
            this.gameObject.GetComponent<Image>().sprite = musicOf;
        }
        else
        {
            music.UnPause();
            this.gameObject.GetComponent<Image>().sprite = musicOn;
        }
    }
}
