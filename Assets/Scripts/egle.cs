using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egle : Enemy
{
    public float up, down;
    public float movespeed;


    public Transform downpos, uppos;
    public Animator Enemy;
    private Rigidbody2D rg;
    public Collider2D coll;
    public bool upping = true;

    protected override void Start()
    {
        base.Start();
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        transform.DetachChildren();
        down = downpos.transform.position.y;
        up = uppos.transform.position.y;
        Destroy(downpos.gameObject);
        Destroy(uppos.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (upping)
        {
            rg.velocity = new Vector2(rg.velocity.x, movespeed);
            if (transform.position.y > up)
            {
                upping = false;
            }
        }
        else
        {
            rg.velocity = new Vector2(rg.velocity.x, -movespeed);
            if (transform.position.y < down)
            {
                upping = true;
            }
        }
    }

}
