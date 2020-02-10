using UnityEngine;
using System.Collections;

public class EnemyWalker : MonoBehaviour
{
    //can change speed of enemies movement through unity 
    public float speed;
    public bool moveRight;


    // Update is called once per frame
    public void Update()
    {
        //if the boolean moveRight is true, the enemy moves in the right direction
        if (moveRight)
        {
           transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        //if the boolean moveRight is false, the enemy moves in the left direction
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }

    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        //checks if player collides with empty game object with tag "Turn" it changes the direction of movement
        if (trig.gameObject.CompareTag("Turn"))
        {
            //if object is moving right and collides, boolean turns false 
            if (moveRight)
            {
                moveRight = false;
            }
            //if object is moving left and collides, boolean turns true 
            else
            {
                moveRight = true;
            }
        }
    }



}
