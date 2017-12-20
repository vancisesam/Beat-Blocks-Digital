using UnityEngine;
using System.Collections;

public class changeNumButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void callNext()
    {
        gameObject.GetComponentInParent<follow>().myBlock.GetComponent<blockInfo>().next();
    }
    public void callPrevious()
    {
        gameObject.GetComponentInParent<follow>().myBlock.GetComponent<blockInfo>().previous();
    }
}
