using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); //destroys bullet
            Destroy(other.gameObject); //destroys enemy
        } 
        //makes sure the bullet is not destoryed when it hits the clue but gets destroyed when it hits other gameobjects 
        else if(!other.gameObject.CompareTag("clue") )
            { Destroy(gameObject); }
    }
}
