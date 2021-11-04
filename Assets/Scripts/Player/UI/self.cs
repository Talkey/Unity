using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self : MonoBehaviour
{

    public GameObject switch_shoot_state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot_state_fade()
    {
        switch_shoot_state.SetActive(false);
    }
}
