using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickingPlayer : PlayerControl
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
            if (_direction == true)
            {
                animator.SetTrigger("kick"); //kicks in right direction
                _kicked = true; // sets kicked to true so enemy can be destroyed
            }
            else if (_direction == false)
            {
                animator.SetBool("left", true);
                animator.SetTrigger("kick"); //kicks in left direction
                _kicked = true;

            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
