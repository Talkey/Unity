using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rg;
    private Collider2D cd;
    private Animator anim;
    public Collider2D HeadCollider;

    public LayerMask Ground;
    public bool isOnGround;
    public Transform groundcheck;
    private bool Hurted = false;
    public bool canjump=true;


    [Header("½ÇÉ«²ÎÊý")]
    public float speed,Jump_force;
    public int Jumptime;
    bool jump_press;
    bool isjump;
    public Text CherryNums, DimondNums;

    [SerializeField]
    public int Cherry = 0, Dimond=0;

    [Header("ÒôÆµ")]
    public  AudioSource Hurted_au;
    public AudioSource Jump;
    public AudioSource Collect_cherry;
    public AudioSource Collect_dimond;


    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cd = GetComponent<Collider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && Jumptime>0)
        {
            jump_press = true;

         }

        SwitchAnim();
        Crouching();
    }

    private void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, 0.1f, Ground);

        Movement();

        Jumping();

        SwitchAnim();

        
    }

    void Movement()
    {
        float Horizontal_x = Input.GetAxisRaw("Horizontal");
        rg.velocity = new Vector2(Horizontal_x * speed , rg.velocity.y);

        if (Horizontal_x != 0)
        {
            transform.localScale = new Vector3(Horizontal_x, 1, 1);
        }Crouching();
    }

    void Jumping()
    {
        if(isOnGround)
        {
            Jumptime = 2;
            isjump = false;
            anim.SetBool("falling", false);
        }

        if(jump_press && isOnGround)
        {
            isjump = true;
            anim.SetBool("jumping", true);
            rg.velocity = new Vector2(rg.velocity.x, Jump_force);
            Jumptime--;
            jump_press =false;
        }

        else if(jump_press && Jumptime>0 && isjump)
        {
            anim.SetBool("jumping", true);
            rg.velocity = new Vector2(rg.velocity.x, Jump_force);
            Jumptime--;
            jump_press = false;
        }
    }



    public void Crouching()
    {
        if (Input.GetButtonDown("Crouch") && cd.IsTouchingLayers(Ground))
        { 
            anim.SetBool(name: "crouching", value: true);
            HeadCollider.enabled = false;
        }
            
        else if(Input.GetButtonUp("Crouch"))
        {
            anim.SetBool(name: "crouching", value: false);
            HeadCollider.enabled = true;
        }
       
    }


    void SwitchAnim()
    {
        anim.SetFloat("startrun", Mathf.Abs(rg.velocity.x));
        if (cd.IsTouchingLayers(Ground))
        {
            anim.SetBool("falling", false);
        }

        if (rg.velocity.y>0 && !cd.IsTouchingLayers(Ground))
        {
            anim.SetBool("jumping", true);
        }

        if (rg.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }

        

        else if(Hurted)
        {
            anim.SetBool("idle", false);
            anim.SetBool("hurted", true);
            if(Mathf.Abs(rg.velocity.x)<0.1f)
            {
                Hurted = false;
                anim.SetBool("hurted", false);
                anim.SetBool("idle", true);
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cherry")
        {
            Destroy(collision.gameObject);
            Collect_cherry.Play();
            Cherry++;
            CherryNums.text = Cherry.ToString();
        }
        if(collision.tag=="dimond")
        {
            Destroy(collision.gameObject);
            Collect_dimond.Play();
            Dimond++;
            DimondNums.text = Dimond.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemies")
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (anim.GetBool("falling"))
            {
                enemy.DeathDestory();
                rg.velocity = Vector2.up * Jump_force/2 * Time.deltaTime;
                anim.SetBool("jumping", true);
            }
            else if(transform.position.x<collision.transform.position.x)
            {
                Hurted_au.Play();
                rg.velocity = new Vector2(-10, 4);
                Hurted = true;
            }
            else if (transform.position.x > collision.transform.position.x)
            {
                Hurted_au.Play();
                rg.velocity = new Vector2(10, 4);
                Hurted = true;

            }
        }
    }


}


    




    

   

