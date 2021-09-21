using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmove : MonoBehaviour
{
    public Transform player;
    public float smoothspeed,movespeed;

    public Renderer bgrend;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bgrend.material.mainTextureOffset += new Vector2(smoothspeed * Time.deltaTime,0f);
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(player.position.x, transform.position.y, 
            transform.position.z), movespeed * Time.deltaTime);
    }
}
