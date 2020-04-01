using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    private bool pickUpAllowed;
    public GameObject clue, congratsPopUp;
    public bool canDestroy;
    
    // Update is called once per frame
    public void Update()
    {
        //if the variable is true and the F button is being pressed, then the pickUp function is called
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.F))
        {
            PickUp();
            if (canDestroy)
            {
                ClueCounterScript.clueCount += 1;
            }
        }
        //if the variable is false but the button is pushed, deduct a point from the score 
        else if (Input.GetKeyDown(KeyCode.F) && pickUpAllowed == false)
        {
            ScoreScript.countValue -= 1;
        }

    }

    //pickUpAllowed is a bool variable
    //when the player is colliding with an object with the clue tag, the boolean variable is true
    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.tag.Equals("clue"))
        {
            pickUpAllowed = true;
        }
    }

    //once you exit the area in which they the tagged item and the player collide, the bool variable is now false
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("clue"))
        {
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        //activates pop up canvas that displays info of the clue found
        clue.SetActive(true);
        //this pauses the enemy spawner and walker so the player isn't killed while the pop up appears
        Pause.isPaused = true;
        //destroys the object that the clue was hidden within
        if (canDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void NewLevel()
    {
        //deactivates popup 
        congratsPopUp.SetActive(false);

        //loads new level
        SceneManager.LoadScene("Level 2");

        ClueCounterScript.level = 2;
        ClueCounterScript.clueCount = 0;
    }

    private void SuspectChoosing()
    {
       congratsPopUp.SetActive(false);
        //loads new level
        SceneManager.LoadScene("SuspectPage");

        ClueCounterScript.level = 2;
        ClueCounterScript.clueCount = 0;
    }

    public void OkButton()
    {
        //closes the canvas by setting it false
        clue.SetActive(false);
        
        //unpauses the enemy spawner and walker
        Pause.isPaused = false;

        //checks what level the player is on and if they found all the clues
        if (ClueCounterScript.level == 1 && ClueCounterScript.clueCount == 3)
        {
            //activates pop up canvas that displays a congrats message
            congratsPopUp.SetActive(true);
            //this pauses the enemy spawner and walker so the player isn't killed while the pop up appears
            Pause.isPaused = true;

            Invoke("NewLevel", 3f); //invokes method after a little wait 

        }
        else if (ClueCounterScript.level == 2 && ClueCounterScript.clueCount == 3)
        {
            //activates pop up canvas that displays a congrats message
            congratsPopUp.SetActive(true);
            //this pauses the enemy spawner and walker so the player isn't killed while the pop up appears
            Pause.isPaused = true;

            Invoke("SuspectChoosing", 3f);
            //SceneManager.LoadScene("SuspectPage");
        }
    }
}

