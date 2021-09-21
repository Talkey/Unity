using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opssum : Enemy
{
    public float left, right;
    public float movespeed;


    public Transform rightpos, leftpos;
    public Animator Enemy;
    private Rigidbody2D rg;
    public Collider2D coll;
    public bool righting = true;

    protected override void Start()
    {
        base.Start();
        rg = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        transform.DetachChildren();
        right = rightpos.transform.position.x;
        left = leftpos.transform.position.x;
        Destroy(rightpos.gameObject);
        Destroy(leftpos.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (righting)
        {
            rg.velocity = new Vector2(movespeed, rg.velocity.y);
            if (transform.position.x > right)
            {
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
                righting = false;
            }
        }
        else
        {
            rg.velocity = new Vector2(-movespeed, rg.velocity.y);
            if (transform.position.x < left)
            {
                transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
                righting = true;
            }
        }
    }

}
