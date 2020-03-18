using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickingPlayer : PlayerControl
{
    static public KickingPlayer K;

    void Awake()
    {
        if (K == null)
        {
            K = this; //sets the singleton
        }
        else
        {
            Debug.LogError("Attempted to assign second Hero.S");
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("moving", false);
        animator.SetBool("left", false);
    }

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_direction == true)
            {
                animator.SetBool("kick", true); //kicks in right direction
                _kicked = true; // sets kicked to true so enemy can be destroyed
            }
            else if (_direction == false)
            {
                animator.SetBool("left", true);
                animator.SetBool("kick", true); //kicks in left direction
                _kicked = true;

            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
