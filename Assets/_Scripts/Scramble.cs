using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scramble : MonoBehaviour
{
    //assign variables in inspector 
    public InputField input;
    public string answer;
    public GameObject clue;
    public GameObject scrambler;
    public GameObject file;


    public void SetAndGetText()
    {
        //when okay button is pressed convert the input to a string
        answer = input.text;
        
        //if the answer is correct increase the clue counter, remove clue objects from screen
        if (answer == "envelope")
        {
            clue.SetActive(true);
            ClueCounterScript.clueCount += 1;
            Destroy(scrambler);
            file.SetActive(false);
        }
        //if the answer is incorrect when the okay button is pressed, reset the text field 
        else
        {
            input.text = "";
        }
    }

}
