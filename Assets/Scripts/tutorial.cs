using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tutorial : MonoBehaviour {
    /*
        Instructions:
        1. Welcome to Name Here!  This app will let you compose music, just by building with blocks! Click the arrow to get started!

        2. First, drag a block in the tool bar on the left into the grid.
        3. Notice your options in the menu at the bottom of the screen.  From here, you can change the number of the block, and click the headphones to listen to what each one sounds like.  Try to find one you like!
        4. Now drag in another block, of a different color.  Place it on top of your first block.  Feel free to change the number and test what your new block sounds like!
        5. Drag in one last block, and place it directly to the right of your first block. Change the number as you wish.
        6. Click on the background, so you havent selected any blocks, then press the play button in the lower left corner, and listen to the song you have created!
        7. This is the end of the tutorial.  Let's hear what you can create!












    */
    public int n = 0;
    private string[] instructions = new string[] { "Welcome to Beat Blocks!  This app will let you compose music, just by building with blocks! Click the arrow to get started!", "First, drag a block in the tool bar on the left into the grid.", "Notice your options in the menu at the bottom of the screen.  From here, you can change the number of the block, and click the headphones to listen to what each one sounds like.  Try to find one you like!", "Now drag in another block, of a different color.  Place it on top of your first block.  Feel free to change the number and test what your new block sounds like!", "Drag in one last block, and place it directly to the right of your first block. Change the number as you wish.", "Click on the background, so you havent selected any blocks, then press the play button in the lower left corner, and listen to the song you have created!", "This is the end of the tutorial.  Let's hear what you can create!" };
    public GameObject previous;
	// Use this for initialization
	void Start () {
        setText();
	}
    public void setText()
    {
        if (n == 0)
        {
            previous.SetActive(false);
        }
        else if (!previous.activeSelf)
        {
            previous.SetActive(true);
        }
        gameObject.GetComponentInChildren<Text>().text = (n+1).ToString() + ".  " + instructions[n];
    }
    public void nextInstruction()
    {
        n++;
        if(n>(instructions.Length - 1))
        {
            endTutorial();
        }
        setText();
    }
    public void previousInstruction()
    {
        n--;
        setText();
    }
    void endTutorial()
    {
        gameObject.SetActive(false);
    }
}
