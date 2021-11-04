using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKBullet : MonoBehaviour,Bullet
{
    private int harm_value;
    public float speed;

    public Collider Bullet_cd;

    //public Animator Crash;
    //public GameObject BulletHole;
    public  Rigidbody rg;

    public void Hurt()
    {
        
    }

    void Start()
    {

        //rg.velocity = transform.TransformDirection(Vector3.forward * speed);

    }

    // Update is called once per frame
    void Update()
    {
        rg.velocity = transform.TransformDirection(Vector3.forward*speed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Hurt();
        Destroy(gameObject,0.2f);
        //GameObject bullethole = Instantiate(BulletHole, transform.position, transform.rotation);
    }





}
