using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class blockInfo : MonoBehaviour {
    public int type;
    public int num;
    private float clipLength;
    public AudioClip[] drums;
    public AudioClip[] melody;
    public AudioClip[] harmony;
    public AudioClip[] bass;
    public AudioClip[][] audioClips = new AudioClip[4][];
    public Sprite[] sprites;
    public Color originalColor;
    public Color colorMod;
    public Button playButton;
    private GameObject musicPlayer;
    AudioSource Audio;
    private bool web;
    // Use this for initialization
    void Start () {
        playButton = GameObject.Find("Play").GetComponent<Button>();
        num = 0;
        Audio = gameObject.GetComponent<AudioSource>();
        audioClips[0] = drums;
        audioClips[1] = bass;
        audioClips[2] = harmony;
        audioClips[3] = melody;
        musicPlayer = GameObject.Find("musicPlayer");
        clipLength = musicPlayer.GetComponent<musicPlayer>().clipLength;
        //gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        web = (Application.platform == RuntimePlatform.WebGLPlayer);
    }

    public void next()
    {
        num++;
        if (num > audioClips[type].Length - 1)
        {
            num = 0;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[num];
    }
    public void previous()
    {
        num--;
        if (num < 0)
        {
            num = audioClips[type].Length - 1;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[num];
    }
    public void activeColor(Color color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
    public void play(float delay)
    {
        Debug.Log("I heard him tell me to play");
        playButton.GetComponentInParent<Image>().sprite = musicPlayer.GetComponent<musicPlayer>().stopImage;
        musicPlayer.GetComponent<musicPlayer>().isPlaying = true;
        Audio.clip = audioClips[type][num];
        double nextEventTime = AudioSettings.dspTime + delay;
        if (!web)
        {
            Audio.PlayScheduled(nextEventTime); //it appears that AudioSource.PlayScheduled() is not supported on WebGL Target Platform
        }
        StartCoroutine(changeColor(delay,colorMod));
    }
    IEnumerator changeColor(float delay, Color color)
    {
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<SpriteRenderer>().color = color;
        
        if (color == colorMod) //this will only trigger the first time changeColor() is called
        {
            if (web)
            {
                Audio.Play();
            }
            StartCoroutine(changeColor(clipLength ,originalColor ));
        }
    }

}
