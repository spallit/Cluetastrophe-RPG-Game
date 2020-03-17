using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public Rigidbody2D _rb;
    public bool _direction; //this variable will help make sure the animations correspond to the right direction
    public bool _kicked; //this will destroy the enemy 
    public GameObject GObject;


    // Start is called before the first frame update
   protected virtual void Start()
    {
       _rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("moving", false);
        animator.SetBool("left", false);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //deactivates all animations so player is just standing
        animator.SetBool("left", false);
        // animator.SetTrigger("jump");
        //animator.SetTrigger("kick");
        //animator.SetTrigger("punch");
         animator.SetBool("moving", false);

        float xAxis = Input.GetAxis("Horizontal");
        Move(xAxis);
        Jump();

        Vector2 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        transform.position = pos;
    }

    public void Move( float x)
    {
        if (x > 0)
        {
            animator.SetBool("moving", true); //player is moving to the right
            _direction = true; //direction will be set to true so other animations can be activated correctly

        }
        else if (x < 0)
        {
            animator.SetBool("left", true);
            animator.SetBool("moving", true); // player is moving to the left
            _direction = false; //direction will be set to true so other animations can be activated correctly
        }
        else if (x == 0)
        {
            animator.SetBool("left", false);
            animator.SetBool("moving", false); //deactivates the walking animations
        }

        // moves the player at the right speed along the x-axis
        Vector2 pos = transform.position;
        pos.x += x * speed * Time.deltaTime;
        transform.position = pos;
    }


    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            float jumpVelocity = 10f;
            _rb.velocity = Vector2.up * jumpVelocity;

            if (_direction == true)
            {
                animator.SetTrigger("jump"); //jumps in right direction

            }
            else if (_direction == false)
            {
                animator.SetBool("left", true);
                animator.SetTrigger("jump"); //jumps in left direction

            }
        } }


        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            //checks if game object has tag that tells them if this is an enemy 
            if (other.gameObject.tag.Equals("Enemy") && _kicked == false)
            {
                gameObject.SetActive(false);
                GObject.SetActive(true);
            }
            else if (_kicked = true && other.gameObject.tag.Equals("Enemy"))//runs if the player kicked the enemy
            {
                Destroy(other.gameObject); // destroys enemy
                                           // animator.SetBool("kick", false); //sets kick back to false so player has to press space again to kll next enemy
            }

        }
    } 
     

