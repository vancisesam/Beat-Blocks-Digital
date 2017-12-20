using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class follow : MonoBehaviour {

    // Use this for initialization
    public GameObject myBlock;
    public Text label;
	void Start()
    {
    }
	// Update is called once per frame
	void Update () {
        if (myBlock != null)
        {
            transform.position = myBlock.transform.position;
            //int display = myBlock.GetComponent<blockInfo>().num + 1;
            //gameObject.GetComponent<Text>().text = display.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
        
	}
}
