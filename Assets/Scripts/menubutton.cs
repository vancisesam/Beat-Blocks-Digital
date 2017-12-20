using UnityEngine;
using System.Collections;

public class menubutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void callNext()
    {
        gameObject.GetComponentInParent<menu>().target.GetComponent<blockInfo>().next();
    }
    public void callPrevious()
    {
        gameObject.GetComponentInParent<menu>().target.GetComponent<blockInfo>().previous();
    }
    public void test()
    {
        //Play the sound

        GameObject.Find("musicPlayer").GetComponent<musicPlayer>().stopPlayingAll();
        gameObject.GetComponentInParent<menu>().target.GetComponent<blockInfo>().play(0);

    }
    public void delete()
    {
        GameObject temp = gameObject.GetComponentInParent<menu>().target;
        gameObject.GetComponentInParent<menu>().deactivate();
        Destroy(temp);
    }
}
