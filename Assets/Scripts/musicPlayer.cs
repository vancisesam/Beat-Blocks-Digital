using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;


public class musicPlayer : MonoBehaviour {
    // Use this for initialization
    private GameObject[] blocks;
    public float clipLength;
    public AudioClip[] audioClips;
    private AudioSource Audio;
    public Image menu;
    private float maxIndex = 0;
    public bool isPlaying = false;
    public Sprite stopImage;
    public Sprite playImage;
    public Button playButton;
    void Start () {
        Audio = GetComponent<AudioSource>();
        menu = GameObject.Find("menu").GetComponent<Image>();
        playButton = GameObject.Find("Play").GetComponent<Button>();
        playImage = playButton.GetComponentInParent<Image>().sprite;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void doTheThing()
    {
        //menu.GetComponent<menu>().deactivate();
        if (isPlaying)
        {
            stopPlayingAll();
            
            return;
        }
        else {
           
            stopPlayingAll();
            buildMap();
        }
    }

    void playMap()
    {
        float maxIndex = 0;
        float minIndex = 100;
        foreach(GameObject block in blocks)
        {
            if (block != null)
            {
                float columnIndex = block.transform.position.x / block.GetComponent<clickanddrag>().gridSize.x;
                if (columnIndex> maxIndex)
                {
                    maxIndex = columnIndex;
                }
                if (columnIndex < minIndex)
                {
                    minIndex = columnIndex;
                }
                block.GetComponent<blockInfo>().play((columnIndex - minIndex) * clipLength);
            }
        }
        StartCoroutine(waitTillStop(((maxIndex - minIndex)+ 1.0f)* clipLength));
        maxIndex = 0;
    }

    IEnumerator waitTillStop(float time)
    {
        yield return new WaitForSeconds(time);
        playButton.GetComponentInParent<Image>().sprite = playImage;
        isPlaying = false;
    }

    public void buildMap()
    {
        blocks = null;
        blocks = GameObject.FindGameObjectsWithTag("block");
        if (blocks.Length == 0)
        {
            Debug.Log("There are no blocks in play");
            return;
        }
        Debug.Log("Start Playing");
        isPlaying = true;
        playButton.GetComponentInParent<Image>().sprite = stopImage;
        playMap();
    }
    public void stopPlayingAll()
    {
        playButton.GetComponentInParent<Image>().sprite = playImage;
        isPlaying = false;
        blocks = GameObject.FindGameObjectsWithTag("block");
        foreach(GameObject block in blocks)
        {
            block.GetComponent<AudioSource>().Stop();
            block.GetComponent<SpriteRenderer>().color = block.GetComponent<blockInfo>().originalColor;
            block.GetComponent<blockInfo>().StopAllCoroutines();
            StopAllCoroutines();
        }
    }
}
