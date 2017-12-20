using UnityEngine;
using System.Collections;

public class gridBehavior : MonoBehaviour {


    public GameObject horizontal;
    public GameObject vertical;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void displayGrid(bool bol)
    {
        vertical.SetActive(bol);
        horizontal.SetActive(bol);
    }
}
