using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueCounterScript : MonoBehaviour
{
    public static int clueCount = 0; //counts points
    public Text countText; //text variable that holds the reference for the Text game object


    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "Clues Found: " + clueCount + "/3";
    }
}
