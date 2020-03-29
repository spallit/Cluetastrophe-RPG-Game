using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
   
    public void Play()
    {
        //if the start button on the instructions screen is pressed, go to level 1 
        SceneManager.LoadScene("Level 1");
    }
}
