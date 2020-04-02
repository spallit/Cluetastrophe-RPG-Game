using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueCounterScript : MonoBehaviour
{
    public static int clueCount = 0; //counts points
    public Text countText; //text variable that holds the reference for the Text game object
    public static int level = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //this updates the Clue Counter Text
        countText.text = "Clues Found: " + clueCount + "/3";

    }


}
