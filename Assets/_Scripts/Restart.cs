using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Restart : MonoBehaviour
{
    
    public void RestartGame()
    {
        //if the restart button is pressed, go to the level 1 screen and start again
        SceneManager.LoadScene("Phase 1"); 
    }
}
