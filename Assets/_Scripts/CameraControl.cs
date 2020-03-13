using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    //calculate offset so the camer is always the same distance from the player
    void Start()
    {
        //startingPos.x = 0.5f;
        //startingPos.y = 0;
        //  Instantiate(player,startingPos, Quaternion.identity);
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    //update camera every frame so it moves with respect to offset and follows player
    void Update()
    {
        transform.position = player.transform.position + offset;
    }


}
