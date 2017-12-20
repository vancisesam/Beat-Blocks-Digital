using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class clickanddrag : MonoBehaviour
{
    private bool enoughTime = false;
    public float speed = 1.0f;
    public float pickupLag;
    public float scale;
    private Vector3 originalSize;
    private Vector3 originalBoxSize;
    private Vector3 originalPos;
    public Vector3 gridSize;
    public Vector3 point;
    public GameObject map;
    public GameObject canvas;
    public Image menu;
    public GameObject grid;
    public GameObject box;
    
    
    public Image trash;
    void Start()
    {
        //canvas = GameObject.Find("Canvas");
        menu = GameObject.Find("menu").GetComponent<Image>();
        grid = GameObject.FindGameObjectWithTag("grid");
        box = GameObject.Find("selectedBox");
    }
    void OnMouseDown()
    {
        //menu.GetComponent<menu>().deactivate();  don't call this, otherwise anywhere you click will throw an error
        menu.GetComponent<menu>().activate(gameObject);

        UnityEngine.Cursor.visible = false;
        originalPos = gameObject.transform.position;
        originalSize = gameObject.transform.localScale;
        originalBoxSize = box.transform.localScale;

    }
    void OnMouseDrag()
    {
        if (!enoughTime)
        {
            StartCoroutine(timer(pickupLag, enoughTime));
            
        }
        if(enoughTime)
        {
            grid.GetComponent<gridBehavior>().displayGrid(true);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            gameObject.transform.localScale = originalSize * scale;
            box.transform.localScale = originalBoxSize * scale;
            point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = gameObject.transform.position.z;
            gameObject.transform.position = point;
        }

    }
    IEnumerator timer(float delay,bool bol)
    {
        yield return new WaitForSeconds(delay);
        enoughTime = true;
    }

    void OnMouseUp()
    {
        grid.GetComponent<gridBehavior>().displayGrid(false);
        StopAllCoroutines();
        enoughTime = false;
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        menu.GetComponent<menu>().activate(gameObject);
        gameObject.transform.localScale = originalSize;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        box.transform.localScale = originalBoxSize;
        //Debug.Log(GetComponent<Collider>().bounds.size.x);
        //gridSize.x = GetComponent<Collider>().bounds.size.x;
        //gridSize.y = GetComponent<Collider>().bounds.size.y;
        UnityEngine.Cursor.visible = true;
        Vector3 endPosition = new Vector3(Mathf.Round(point.x / gridSize.x) * gridSize.x, Mathf.Round(point.y / gridSize.y) * gridSize.y, 0.0f);
        /*if (checkDelete(point))
        {
            Destroy(gameObject);
        }
        else if (checkTest(point))
        {
            //Play the sound
            GameObject.Find("musicPlayer").GetComponent<musicPlayer>().stopPlayingAll();
            gameObject.GetComponent<blockInfo>().play(0);
            transform.position = originalPos;
        }*/
        if (validPosition(endPosition, gameObject))
        {
            transform.position = endPosition;
        }
        else
        {
            transform.position = originalPos;
        }
        //check to see if endPosition is valid by collision?

        

        //}
    }
    public bool validPosition(Vector3 pos, GameObject me)
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("block");
        foreach(GameObject block in blocks)
        {
            if (block != me)
            {
                if (pos == block.transform.position)
                {
                    Debug.Log("on top of another block");
                    return false;
                }
            }
        }
        RectTransform bound = canvas.GetComponent<RectTransform>();
        //if (pos.x < 0 || pos.x > Camera.main.transform.position.x + bound.rect.width / 100 || pos.y < 0 || pos.y > Camera.main.transform.position.y + bound.rect.height / 100)
        if (pos.x < 0 || pos.x > 16.0f || pos.y < 0 || pos.y > 8.0f)
        {   //divide by 2, divide by 100 pixels per unity unit
            Debug.Log(Camera.main.transform.position.x );
            Debug.Log(bound.rect.width / 100);
            Debug.Log("out of bounds");
            return false;
        }
        return true;
    }
    public bool checkDelete(Vector3 pos)
    {
        RectTransform tbound = trash.GetComponent<RectTransform>();
        //Debug.Log((-tbound.rect.width + tbound.position.x)/100);
        //Debug.Log(pos.x);
        //Debug.Log((tbound.rect.width + tbound.position.x)/100);
        RectTransform bound = canvas.GetComponent<RectTransform>();
        if (pos.y<0 && pos.x>17.6f )
        {
            Debug.Log("put in the trash");
            return true;
            
        }
        else
        {
            return false;
        }
    }
    public bool checkTest(Vector3 pos)
    {
        
        RectTransform bound = canvas.GetComponent<RectTransform>();
        //Debug.Log(pos.x.ToString() + "    " +  pos.y.ToString());
        if (pos.y < 0 && pos.x > 2.5f && pos.x<4.7f)
        {
            Debug.Log("Play this Block!");
            return true;

        }
        else
        {
            return false;
        }
    }

}