using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    public float left, right;
    public float movespeed,jumpforce;
    public bool faceleft = true;


    public Transform leftpos, rightpos;
    public Animator Enemy;
    private Rigidbody2D rg;
    public LayerMask Ground;
    public Collider2D coll;

    protected override void Start()
    {
        base.Start();
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        transform.DetachChildren();
        left = leftpos.transform.position.x;
        right = rightpos.transform.position.x;
        Destroy(leftpos.gameObject);
        Destroy(rightpos.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnim();
    }

    public void Move()
    {
        if (faceleft)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                Enemy.SetBool("jump", true);
                rg.velocity = new Vector2(-movespeed, jumpforce);
            }
            if (transform.position.x < left)
            {
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
                faceleft = false;
            }
            
        }
        else
        {
            if (coll.IsTouchingLayers(Ground))
            {
                Enemy.SetBool("jump", true);
                rg.velocity = new Vector2(movespeed, jumpforce);
            }
            if (transform.position.x > right)
            {
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
                faceleft = true;
            }
        }
    }

    public void SwitchAnim()
    {
       
        if (Enemy.GetBool("jump"))
        {
            if (rg.velocity.y < 0.1f)
            {
                Enemy.SetBool("fall", true);
                Enemy.SetBool("jump", false);
            }
            
        }
        if (coll.IsTouchingLayers(Ground)&& Enemy.GetBool("fall"))
            {
                Enemy.SetBool("fall", false);
               
            }
    }
}
