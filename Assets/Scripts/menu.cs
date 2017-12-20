using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {
    public GameObject target;
    //public Rect menuBar;
    public RectTransform menuBar;
    public float dropRate = 5.0f;
    public GameObject buttons;
    public Slider volumeSlider;
    public GameObject box;
    private Color myColor;
    public Button playButton;
    
	// Use this for initialization
	void Start () {
        myColor = box.GetComponent<SpriteRenderer>().color;
        playButton = GameObject.Find("Play").GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            box.transform.position = target.transform.position;     //the box should follow the target
        }
	}


    public void activate(GameObject selected)
    {
        Debug.Log("activate called");
        GameObject.Find("musicPlayer").GetComponent<musicPlayer>().stopPlayingAll();
        
        if (target != null)
        {
            deactivate();
        }
        playButton.interactable = false;
        myColor.a = box.GetComponent<alphaValue>().alpha;                                   //set the box to be visible
        box.GetComponent<SpriteRenderer>().color = myColor;
        target = selected;
        //target.GetComponent<blockInfo>().activeColor(target.GetComponent<blockInfo>().colorMod);
        buttons.SetActive(true);
        //set the volume bar to have the correct volume value
        volumeSlider.value = target.GetComponent<AudioSource>().volume;
    }

    public void deactivate()
    {
        playButton.interactable = true;
        if (target != null)
        {
            //target.GetComponent<blockInfo>().activeColor(target.GetComponent<blockInfo>().originalColor);
            target = null;
            myColor.a = 0;                                           //set the outline of the block to be invisible
            box.GetComponent<SpriteRenderer>().color = myColor;
        }
       
        
        buttons.SetActive(false);
    }
    public void setVolume()
    {
        target.GetComponent<AudioSource>().volume = volumeSlider.value;
    }
    /*public void next()
    {
        blockInfo info = target.GetComponent<blockInfo>();
        target.GetComponent<blockInfo>().num++;
        if (target.GetComponent<blockInfo>().num > info.audioClips[info.type].Length - 1)
        {
            target.GetComponent<blockInfo>().num = 0;
        }
        target.GetComponent<SpriteRenderer>().sprite = info.sprites[info.num];
    }
    public void previous()
    {
        blockInfo info = target.GetComponent<blockInfo>();
        target.GetComponent<blockInfo>().num--;
        if (target.GetComponent<blockInfo>().num < 0)
        {
            target.GetComponent<blockInfo>().num = info.audioClips[info.type].Length - 1;
        }
        target.GetComponent<SpriteRenderer>().sprite = info.sprites[info.num];
    }*/
}
