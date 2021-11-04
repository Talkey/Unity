using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public UIcontroller UI;



    public  Rigidbody Player;
    public Transform Player_trans;
    private CapsuleCollider Player_colider;
    public GameObject crou;
    public Animator character_action;
    public LayerMask Ground;


    [Header("相机")]
    public Transform  main_camera;
    public  Vector3 camera;
    //private float cameraspeed=5;
    //private float mousespeed=5;
    public Vector2 Max_Min_Angle;


    [Header("角色不同状态基本速度")]
    [SerializeField] private float run_speed;
    [SerializeField] private float walk_speed;
    [SerializeField] public float current_speed;


    [Header("角色跳跃和冲刺")]
    public int Health;
    public int Jump_time=2;
    public float dash_Time_distance;
    public float dash_time=0;
    public bool Dashing = false;
    public float jump_Force=10f;

    [Header("角色下蹲数据")]
    [SerializeField] private float crouch_speed;


    [Header("角色动作布尔值判断")]
    [SerializeField]public bool can_Jump = true;
    [SerializeField] private bool jump_Click = false;
    //[SerializeField] private bool Crouch=false;
    [SerializeField] private bool moving = false;

    [Header("混合数据")]
    public float blend_speed;

    //[Header("玩家射击数据")]
    //public static bool continuous_shooting;

    public void Awake()
    {
        Cursor.lockState= CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        //continuous_shooting = UI.con_shoot;
        Player_trans = GetComponent<Transform>();
        Player_colider = GetComponent<CapsuleCollider>();
    }


    // Update is called once per frame
    void Update()
    {
        Switch_state();
        Jump_Click();
        Player_Move();
        Crouching();
        Jump();
        //shoot();
    }



    public void Player_Move()
    {
        move_judge();
        if (Input.GetKey(KeyCode.CapsLock))
        {
            Dashing = true;
            dash_time +=Time.time;
            Move(9f);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Dashing = false;

            Crouching();
            Move(1f);
        }
        else
        {
            Move(4.8f);
        }
    }

    public void Move(float speed)
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float ver = Input.GetAxis("Mouse X");
        float hor = Input.GetAxis("Mouse Y");

        Vector3 targetDirection = new Vector3(horizontal, 0, vertical);//
        float y = main_camera.transform.rotation.eulerAngles.y;//获取相机沿y轴旋转的角度
        targetDirection = Quaternion.Euler(0, y, 0) * targetDirection;//在自身坐标移动中添加旋转角

        transform.Translate(targetDirection* Time.deltaTime*speed);//A D 左右  W S前后

    }

    public void Jump()
    {
        if(jump_Click&&can_Jump==true)
        {
            Player.velocity= Vector3.up * jump_Force;//W S 上 下  A D 左右
            can_Jump = false;
            jump_Click = false;
            Jump_time--;
        }
        if(jump_Click && Jump_time>=1)
        {
            Player.velocity = Vector3.up * jump_Force;//W S 上 下
            jump_Click = false;
            Jump_time--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            can_Jump = true;
            Jump_time = 2;
        }
    }

    private void Jump_Click()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump_Click = true;
        }
        else
            jump_Click = false;
    }

    /*另外一种移动方式
     void MoveControlByVelocity()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下
        //这个必须分开判断 因为一个物体的速度只有一个
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S))
        {
            m_rigidbody.velocity = Vector3.forward * vertical * m_speed;
        }
        if (Input.GetKey(KeyCode.A)|Input.GetKey(KeyCode.D))
        {
            m_rigidbody.velocity = Vector3.right * horizontal * m_speed;
        }   
    }
     */

    public void Crouching()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        { 
            crou.transform.position = new Vector3(crou.transform.position.x, crou.transform.position.y - 0.2f, crou.transform.position.z);
            //Crouch = true;
            Move(1f);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            crou.transform.position = new Vector3(crou.transform.position.x, crou.transform.position.y + 0.2f, crou.transform.position.z);
            //Crouch = false;
            Move(4.8f);
        }
    }

    public void Switch_state()
    {
        if (moving == true && Input.GetKey(KeyCode.LeftShift))
        {
            blend_parameter(1f,1);
        }

        if (move_judge() == true && Input.GetKey(KeyCode.CapsLock) && Dashing==true)
        {
            blend_parameter(9f,3);
        }

        if (move_judge() == true&&(!Input.GetKey(KeyCode.CapsLock)||Dashing==false))
        {
            blend_parameter(4.8f,1);
        }

        if(move_judge()==false)
        {
            blend_parameter(0f,1);
        }

        Crouching();

    }

    public bool move_judge()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
            moving = true;
        else
            moving = false;
        return moving;
    }

    public void blend_parameter(float target_value,int magnification)
    {
        if(current_speed < target_value)
        {
            current_speed += Time.deltaTime * blend_speed*magnification;
            character_action.SetFloat("Velocity", current_speed);
        }
        if(current_speed > target_value)
        {
            current_speed -= Time.deltaTime * blend_speed * magnification;
            character_action.SetFloat("Velocity", current_speed);
        }
    }

}
