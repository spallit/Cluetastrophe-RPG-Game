using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsScreen : MonoBehaviour
{

    public void Load()
    {
        //when the play button on the main screen is pressed, go to the instructions screen 
        SceneManager.LoadScene("Instructions");
    }
}
