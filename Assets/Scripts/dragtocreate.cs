using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dragtocreate : MonoBehaviour
{
    public GameObject gameBlock;
    public GameObject blockText;
    public float speed = 1.0f;
    public float scale;
    private Vector3 originalSize;
    private Vector3 originalPosition;
    public Vector3 gridSize;
    public Vector3 point;
    public Image menu;
    public GameObject grid;


    // Information about the type of block
    public int type;
    public Color[] colors = new Color[4];
    public Color[] colorsMod = new Color[4];
    void Start()
    {
        colors[0] = new Color(0, 128.0f / 255.0f, 255.0f / 255.0f); //Color.cyan;
        colors[1] = new Color(255.0f / 255.0f, 26.0f / 255.0f, 26.0f / 255.0f); //Color.red;
        colors[3] = Color.green; //Color(39.0f/255.0f, 230.0f/255.0f, 55.0f/255.0f);
        colors[2] = new Color(255.0f/255.0f, 165.0f/255.0f, 0);
        GetComponent<UnityEngine.UI.Image>().color = colors[type];
        colorsMod[0] = new Color(77.0f / 255.0f, 166.0f / 255.0f, 255.0f / 255.0f); //new Color(179.0f/255.0f, 255.0f/255.0f, 255.0f/255.0f);
        colorsMod[1] = new Color(255.0f/255.0f, 77.0f/255.0f, 77.0f/255.0f);
        colorsMod[3] = new Color(77.0f/255.0f, 255.0f/255.0f, 77.0f/255.0f);    //Color(95.0f/255.0f, 236.0f/255.0f, 107.0f/255.0f);
        colorsMod[2] = new Color(255.0f/255.0f, 193.0f/255.0f, 77.0f/255.0f);
        //colorsMod[0] = Color.black;

        menu = GameObject.Find("menu").GetComponent<Image>();
        grid = GameObject.FindGameObjectWithTag("grid");

    }




    //public GameObject map;
    void OnMouseDown()
    {
        originalPosition = gameObject.transform.position;
        UnityEngine.Cursor.visible = false;
        originalSize = gameObject.transform.localScale;
        gameObject.transform.localScale = originalSize * scale;

    }
    void OnMouseDrag()
    {
        grid.GetComponent<gridBehavior>().displayGrid(true);
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.z = gameObject.transform.position.z;
        gameObject.transform.position = point;

    }

    void OnMouseUp()
    {
        grid.GetComponent<gridBehavior>().displayGrid(false);
        //Debug.Log(GetComponent<Collider>().bounds.size.x);
        UnityEngine.Cursor.visible = true;
        gameObject.transform.localScale = originalSize;
        Vector3 endPosition = new Vector3(Mathf.Round(point.x / gridSize.x) * gridSize.x, Mathf.Round(point.y / gridSize.y) * gridSize.y, 0.0f);


        GameObject newBlock = Instantiate(gameBlock, endPosition, Quaternion.identity) as GameObject;
        newBlock.GetComponent<blockInfo>().originalColor = colors[type];
        newBlock.GetComponent<blockInfo>().colorMod = colorsMod[type];
        newBlock.GetComponent<blockInfo>().type = type;
        menu.GetComponent<menu>().deactivate();
        menu.GetComponent<menu>().activate(newBlock);
        /*if (newBlock.GetComponent<clickanddrag>().checkDelete(newBlock.transform.position))
        {
            Destroy(newBlock);
        }*/
        if (!newBlock.GetComponent<clickanddrag>().validPosition(newBlock.transform.position, newBlock))
        {
            menu.GetComponent<menu>().deactivate();
            Destroy(newBlock);
        }
        transform.position = originalPosition;
        //GameObject newText = Instantiate(blockText, endPosition, Quaternion.identity) as GameObject;
        //newText.transform.SetParent(GameObject.Find("canvas2").transform, false);
        //newText.GetComponent<follow>().myBlock = newBlock;
    }




}
