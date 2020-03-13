using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //public GameObject player1;
    //public GameObject player2;

    public GameObject player;

    private Vector3 offset;

    //public PunchButton Punch;

    //private Vector2 startingPos;
    
    void Awake()
    {
        //Punch = GetComponent<PunchButton>();
        
    }
    // Start is called before the first frame update
    //calculate offset so the camer is always the same distance from the player
    void Start()
    {

        /* startingPos.x = 0.5f;
         startingPos.y = 0;

        if (Punch.BeginGame() == true)
        {
            Instantiate(player1, startingPos, Quaternion.identity);
            offset = transform.position - player1.transform.position;
        }
        else
        {
            Instantiate(player2, startingPos, Quaternion.identity);
            offset = transform.position - player2.transform.position;
        }*/
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    //update camera every frame so it moves with respect to offset and follows player
    void Update()
    {
        //transform.position = player1.transform.position + offset;
        // transform.position = player2.transform.position + offset;
        transform.position = player.transform.position + offset;
    }


}
