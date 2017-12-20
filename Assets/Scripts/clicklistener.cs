using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clicklistener : MonoBehaviour
{

    public Image menu;
    // Use this for initialization
    void Start()
    {
        menu = GameObject.Find("menu").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        menu.GetComponent<menu>().deactivate();
    }
}
