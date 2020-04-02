using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SceneManagement;


public class SuspectController : MonoBehaviour
{
    public GameObject lost;
    public GameObject won;

    //Corresponds to Suspect 1 
    public void FirstChoice() 
    {
        lost.SetActive(true); //activates the canva that says the player lost
    }

    //Corresponds to Suspect 12
    public void SecondChoice()
    {
        won.SetActive(true); //activates the canva that says the player won
    }

    //Corresponds to Suspect 12
    public void ThirdChoice()
    {
        lost.SetActive(true); //activates the canva that says the player won
    }

    //This method restarts the game  
    public void ReplayButtonPressed()
    {
        //if the restart button is pressed, go to the level 1 screen and start again
        SceneManager.LoadScene("Level 1");
        //score gets reset to 0
        ScoreScript.countValue = 0;
        //clue counter gets reset to 0
        ClueCounterScript.clueCount = 0;
    }

    //This method exits the game
    public void ExitButtonPressed()
    {
        //This stops the application from running in editor
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
