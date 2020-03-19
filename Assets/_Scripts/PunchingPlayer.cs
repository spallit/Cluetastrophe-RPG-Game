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
                animator.SetTrigger("punch"); //punches in right direction
                attacked = true; // sets attacked to true so enemy can be destroyed
            }
            else if (!direction)
            {
                animator.SetBool("left", true);
                animator.SetTrigger("punch"); //punches in left direction
                attacked = true;

            }
        }
    }


    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
