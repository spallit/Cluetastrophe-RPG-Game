using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMain : MonoBehaviour
{

    public void ExitGame()
    {
        //if the quit button is pressed, go to the menu scene 
        SceneManager.LoadScene("Menu");
    }
}