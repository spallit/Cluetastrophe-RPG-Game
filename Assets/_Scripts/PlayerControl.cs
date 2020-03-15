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
        //deactivates animation so player is just standing
         animator.SetBool("moving", false);
        
        //makes sure the player is facing left if they moved in the left direction previously
     

        //gets required input
        float xAxis = Input.GetAxis("Horizontal");
        //calls the move method 
        Move(xAxis);

        //calls jump method if the up arrow was pressed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        //calls shoot method if the correct button is pressed
        if (Input.GetKeyDown(KeyCode.V))
        {
            Shoot();
        }

        if (!_direction)
        {
            animator.SetBool("left", true);
        }

        //changes the position of the player to move it 
        Vector2 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        transform.position = pos;
    }

    // this method activates the moving animations
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

    // this method allows the player to jump and activates the jumo animation 
    public void Jump()
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
        }

    //activates the shoot animations 
    public void Shoot()
    {
        animator.SetTrigger("shoot");
    }


        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            //checks if game object has tag that tells them if this is an enemy 
            if (other.gameObject.tag.Equals("Enemy") && _kicked == false)
            {
                gameObject.SetActive(false);
                //GObject.setActive(true);
            }
            else if (_kicked = true && other.gameObject.tag.Equals("Enemy"))//runs if the player kicked the enemy
            {
                Destroy(other.gameObject); // destroys enemy
                                           // animator.SetBool("kick", false); //sets kick back to false so player has to press space again to kll next enemy
            }

        }
    } 
     

