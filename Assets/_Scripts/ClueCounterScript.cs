using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClueCounterScript : MonoBehaviour
{
    public static int clueCount = 0; //counts points
    public Text countText; //text variable that holds the reference for the Text game object
    private int _level = 1;
    public GameObject clue;

    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "Clues Found: " + clueCount + "/3";

        //checks what level the player is on and if they found all the clues
        if (_level == 1 && clueCount == 3)
        {
            //activates pop up canvas that displays a congrats message
            clue.SetActive(true);
            //this pauses the enemy spawner and walker so the player isn't killed while the pop up appears
            Pause.isPaused = true;

            Invoke("NewLevel", 3f); //invokes method after a little wait 

        } else if (_level == 2 && clueCount == 3)
        {

        }
    }

    private void NewLevel()
    {
        //deactivates popup 
        clue.SetActive(false);

        //loads new level
        SceneManager.LoadScene("Level 2");

        _level = 2;
        clueCount = 0;
    }

    public int level
    {
        get { return _level; }
        set { _level = value; }
    }

}
