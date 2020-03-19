using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //initializing player 
    public GameObject player;

    public Vector3 offset;

    //update camera every frame so it moves with respect to offset and follows player
    void Update()
    {
        //check if player is instantiated 
        if(player != null)
        {
            transform.position = player.transform.position + offset;
        }
        
    }


}
