using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothspeed = 0.8f;
    public Transform player;
    public Transform MaxX, MaxY, MinX, MinY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), smoothspeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX.position.x, MaxX.position.x), 
            Mathf.Clamp(transform.position.y, MinY.position.y, MaxY.position.y), transform.position.z);
    }

}
