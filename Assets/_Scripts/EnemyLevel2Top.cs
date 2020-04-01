using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel2Top : MonoBehaviour
{
    //code randomly spawns enemys in random location 
    //assign game object through unity 
    public GameObject enemy;
    //assigns random x value 
    float randX;
    Vector2 whereToSpawn;
    //spawns new enemy every 10 seconds 
    public float spawnRate = 10f;
    float nextSpawn = 0.0f;


    // Update is called once per frame
    void Update()
    {
        if (!Pause.isPaused)
        {
            //checks time with variable nextSpawn, simulating a timer 
            //every time the timer passes 10 more seconds run code
            if (Time.time > nextSpawn)
            {
                //adds 10 seconds to 
                nextSpawn = Time.time + spawnRate;
                //random range is assigned with preset range values 
                randX = Random.Range(35f, 75f);
                //enemies are spawned randomly along the x axis of the game, within the provided range
                whereToSpawn = new Vector2(randX, transform.position.y);
                Instantiate(enemy, whereToSpawn, Quaternion.identity);
            }
        }
    }
}
