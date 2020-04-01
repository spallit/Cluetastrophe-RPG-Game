using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Restart : MonoBehaviour
{
    
    public void RestartGame()
    {
        //if the restart button is pressed, go to the level 1 screen and start again
        SceneManager.LoadScene("Level 1");
        //score gets reset to 0
        ScoreScript.countValue = 0;
        ClueCounterScript.clueCount = 0;
        ClueCounterScript.level = 1;
    }
}
