using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonScript : MonoBehaviour
{
    public GameObject clue;
    // Start is called before the first frame update
    public void OkButton()
    {
        //closes the canvas by setting it false
        clue.SetActive(false);
        Pause.isPaused = false;
    }
}
