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
        else { Destroy(gameObject); }
    }
}
