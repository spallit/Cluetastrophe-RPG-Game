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

    
    public void FirstChoice() 
    {
        lost.SetActive(true);
    }

    public void SecondChoice()
    {
        won.SetActive(true);
    }

    public void ThirdChoice()
    {
        lost.SetActive(true);
    }


    public void ReplayButtonPressed()
    {
        //if the restart button is pressed, go to the level 1 screen and start again
        SceneManager.LoadScene("Level 1");
        //score gets reset to 0
        ScoreScript.countValue = 0;
        //clue counter gets reset to 0
        ClueCounterScript.clueCount = 0;
    }

    public void ExitButtonPressed()
    {

    }
}
