using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //declare movement vector for 2D motion 
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //force of movement is dependent on speed and direction input my player
        _rb.AddForce(moveInput * speed);

        //jumping controller
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            float jumpVelocity = 10f;
            _rb.velocity = Vector2.up * jumpVelocity;
        }
    }
}

