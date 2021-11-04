using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmove : MonoBehaviour
{

    private Transform characterTrans;//物体坐标
    private Rigidbody character_rigidbody;//物体的刚体，需要用到速度

    public float walkspeed;//行走速度


    void Start()
    {
        characterTrans = transform;//开始的时候获取到坐标
        character_rigidbody = GetComponent<Rigidbody>();//获取刚体组件
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var move_x = Input.GetAxis("Horizontal");//x和y轴输入
        var move_y = Input.GetAxis("Vertical");

        var character_current_direction = new Vector3(move_x, move_y);//根据键盘输入获取当前角色移动方向
        character_current_direction =characterTrans.TransformDirection(character_current_direction);//把自身坐标转换为世界坐标

        character_current_direction *= walkspeed;//移动方向乘上速度，积分？

        var current_Velocity = character_rigidbody.velocity;//获取到当前的速度
        var Velocity_Change = character_current_direction - current_Velocity;//速度变量
        current_Velocity.y = 0;//把y轴速度归零，貌似是为了只给角色施加一个力，如果y轴速度不为零则可能变成勾股定理那种加速情况

        character_rigidbody.AddForce(Velocity_Change, ForceMode.VelocityChange);//为刚体施加一个力


    }
}
