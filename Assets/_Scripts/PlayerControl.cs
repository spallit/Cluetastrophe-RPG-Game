using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Animator animator; // this is the animator that will activate animations
    public float speed;
    private float _xAxis;
    private Rigidbody2D _rb;
    private bool _direction; //this variable will help make sure the animations correspond to the right direction
    private bool _attacked; //this will destroy the enemy 
    public GameObject GObject, bulletPrefab;

    static public PlayerControl S; //Creates Singleton

    protected virtual void Awake()
    {
        if (S == null)
        {
            S = this; //sets the singleton
        }
        else
        {
            Destroy(this.gameObject); //destroys the new player gameObject if another one already exists
        }
    }

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
        animator.SetBool("moving", false);
        

        _xAxis = Input.GetAxis("Horizontal");
        Move();

        //calls the jump method if the up arrow is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            Jump();
        }

        //calls the shoot method if the button V is pressed
        if (Input.GetKeyDown(KeyCode.V))
        {
            Shoot();
        }
    }

    void Move( )
    {
        if (_xAxis > 0)
        {
            animator.SetBool("left", false);
            animator.SetBool("moving", true);//player is moving to the right
            _direction = true; //direction will be set to true so other animations can be activated correctly

        }
        else if (_xAxis < 0)
        {
            animator.SetBool("left", true);
            animator.SetBool("moving", true); // player is moving to the left
            _direction = false; //direction will be set to true so other animations can be activated correctly
        }
        else if (_xAxis == 0)
        { 
            animator.SetBool("moving", false); //deactivates the walking animations
        }

        // moves the player at the right speed along the x-axis
        Vector2 pos = transform.position;
        pos.x += _xAxis * speed * Time.deltaTime;
        transform.position = pos;
    }

    //This method allows player to jump and activates corresponding animation
    void Jump()
    {
            // moves the player up on the y-axis
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

    // this method activates the shooting animations
    void Shoot()
    {
        //actiavtes shooting animations in the correct direction
        if (_direction == true)
        {
            animator.SetTrigger("shoot"); //shoots in the right direction

        }
        else if (_direction == false)
        {
            animator.SetBool("left", true);
            animator.SetTrigger("shoot"); //shoots in left direction
        }


        Vector2 pos = this.transform.position;
       
        //makes the x position of the bullet away from the player
        if (_direction)
        {
            pos.x += 1;
        } else if (!_direction) {pos.x -= 1; } 

        GameObject bullet = Instantiate<GameObject>(bulletPrefab);
        bullet.transform.position = pos;
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();

        //moves the bullet in the correct direction
        if (!_direction)
        {
            brb.velocity = Vector2.left * 10;
        }
        else if (_direction)
        {
            brb.velocity = Vector2.right * 10;
        }
    }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            //checks if game object has tag that tells them if this is an enemy 
            if (other.gameObject.tag.Equals("Enemy") && _attacked == false)
            {
                gameObject.SetActive(false);
            
            Instantiate(GObject, transform.position, Quaternion.identity);
        }
            else if (_attacked == true && other.gameObject.tag.Equals("Enemy"))//runs if the player kicked the enemy
            {
                
                Destroy(other.gameObject); // destroys enemy
                //adds 5 points to the score 
                ScoreScript.countValue += 10;
                _attacked = false;
            }

        }

    //These properties allow children to access _direction and _attacked while keeping the fields private
    public bool direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool attacked
    {
        get { return _attacked; }
        set { _attacked = value; }
    }
} 
     

