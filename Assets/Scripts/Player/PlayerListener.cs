using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListener : MonoBehaviour
{
    public voice footaudio;
    public AudioSource footaudiosource;
    public Transform footsteptrans;

    public PlayerController character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<PlayerController>();
        footsteptrans = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(character.can_Jump==true)
        {
            if(character.current_speed>1f)
            {
                Physics.Linecast(footsteptrans.position,character.transform.position);
            }
        }
    }


}
