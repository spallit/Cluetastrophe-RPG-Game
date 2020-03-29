using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingPlayer : PlayerControl
{

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start(); //calls the parent class start method 
    }

    protected override void Update()
    {
        base.Update();
        Attack();
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (direction)
            {
                attacked = true; // sets attacked to true so enemy can be destroyed
                animator.SetTrigger("punch"); //punches in right direction
              
            }
            else if (!direction)
            {
                attacked = true;
                animator.SetBool("left", true);
                animator.SetTrigger("punch"); //punches in left direction
               

            }
        }
    }


    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Attack();
        base.OnTriggerEnter2D(other);
    }
}
