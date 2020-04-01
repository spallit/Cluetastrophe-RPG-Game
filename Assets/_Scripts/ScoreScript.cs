using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int countValue = 0; //counts points
    public Text countText; //text variable that holds the reference for the Text game object
    private int _xpLevel = 1;
    private int _hearts =1;
    public GameObject h2, h3;


    // Start is called before the first frame update
    void Start()
    {
        countText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = "XP Level" + _xpLevel + "   XP points:" + countValue;

        // This increases the expereince level and the lives the player has
        if (countValue >= 50)
        {
            _xpLevel += 1;
            _hearts += 1;
            countValue = 0;
        }

        //these if statements control the heart graphics in the game
        if (_hearts == 1) 
        { 
            h2.SetActive(false);
            h3.SetActive(false);
        }
        else if (_hearts == 2) 
        { 
            h2.SetActive(true);
            h3.SetActive(false);
        }
        else if(_hearts == 3)
        {
            h3.SetActive(true);
        }

    }
}