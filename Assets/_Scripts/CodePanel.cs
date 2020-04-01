using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    
    public Text codeText;
    string codeTextValue = "";
    //game objects to be defined in the inspector 
    public GameObject clue;
    public GameObject button;
    public GameObject machine;
    public GameObject note;


    void Update()
    {
        //sets inital text to nothing
        codeText.text = codeTextValue;

        //if the code entered by the user is correct
        //display the clue and get rid of the button, machine and lock
        if (codeTextValue == "436")
        {
            
            clue.SetActive(true);
            Destroy(gameObject);
            //ClueCounterScript.clueCount += 1;
            button.SetActive(false);
            machine.SetActive(false);
            note.SetActive(false);
        }
        //if the code entered is wrong, reset the lock
        if (codeTextValue.Length >= 3)
        {
            codeTextValue = "";
        }
    }
    //add a number to the code if it the corresponding button is pressed in the game
    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }
}
