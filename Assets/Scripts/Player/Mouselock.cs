using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselock : MonoBehaviour
{
    private Transform camareTrans;
    private Vector3 camerarotation;
    public Vector2 MaxAngle;
    [SerializeField]private Transform characterTrans;

    public float a;
    public float b;
    public float blend_speed;


    public float speed;


    void Start()
    {
        camareTrans = transform;
    }

    // Update is called once per frame
    void Update()
    {

        a=blend_parameter(a, b);
        var tmp_mouseY = Input.GetAxis("Mouse Y");
        var tmp_mouseX = Input.GetAxis("Mouse X");
        camerarotation.y += tmp_mouseX * speed;
        camerarotation.x -= tmp_mouseY * speed;

        //camerarotation.x= Mathf.Clamp(camerarotation.x,MaxAngle.x,MaxAngle.y);

        camareTrans.rotation = Quaternion.Euler(Mathf.Clamp(camerarotation.x, MaxAngle.x, MaxAngle.y), camerarotation.y, z: 0);
        characterTrans.rotation = Quaternion.Euler(camerarotation.x, camerarotation.y, 0);
    }

    public float blend_parameter(float current_value, float target_value)
    {
        if (current_value < target_value)
        {
            current_value += Time.deltaTime * blend_speed;
        }
        if (current_value > target_value)
        {
            current_value -= Time.deltaTime * blend_speed;
        }
        return current_value;
    }
}
