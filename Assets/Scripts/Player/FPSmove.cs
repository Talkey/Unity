using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmove : MonoBehaviour
{

    private Transform characterTrans;//��������
    private Rigidbody character_rigidbody;//����ĸ��壬��Ҫ�õ��ٶ�

    public float walkspeed;//�����ٶ�


    void Start()
    {
        characterTrans = transform;//��ʼ��ʱ���ȡ������
        character_rigidbody = GetComponent<Rigidbody>();//��ȡ�������
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var move_x = Input.GetAxis("Horizontal");//x��y������
        var move_y = Input.GetAxis("Vertical");

        var character_current_direction = new Vector3(move_x, move_y);//���ݼ��������ȡ��ǰ��ɫ�ƶ�����
        character_current_direction =characterTrans.TransformDirection(character_current_direction);//����������ת��Ϊ��������

        character_current_direction *= walkspeed;//�ƶ���������ٶȣ����֣�

        var current_Velocity = character_rigidbody.velocity;//��ȡ����ǰ���ٶ�
        var Velocity_Change = character_current_direction - current_Velocity;//�ٶȱ���
        current_Velocity.y = 0;//��y���ٶȹ��㣬ò����Ϊ��ֻ����ɫʩ��һ���������y���ٶȲ�Ϊ������ܱ�ɹ��ɶ������ּ������

        character_rigidbody.AddForce(Velocity_Change, ForceMode.VelocityChange);//Ϊ����ʩ��һ����


    }
}
