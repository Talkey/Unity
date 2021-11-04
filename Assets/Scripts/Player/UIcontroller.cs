using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public GameObject switch_shoot_state;


    public Animator switch_shoot;
    public Text context;



    public bool con_shoot = false;

    public bool start_time = false;


    public float timedistance = 1.21f;


    void Start()
    {
        start_time = false;
        con_shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        shoot_switch();
    }
    public void shoot_switch()
    {
        if (start_time == true)
        {
            timedistance -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && timedistance > 1.2f)
        {
            start_time = true;
            con_shoot = !con_shoot;
            if (con_shoot == true)
            {
                switch_shoot_state.SetActive(true);
                context.text = " 已经切换为连射模式";
            }
            if (con_shoot == false)
            {
                switch_shoot_state.SetActive(true);
                context.text = " 已经切换为狙击模式";
            }

        }
        if (timedistance <= 0f)
        {
            timedistance = 1.21f;
            start_time = false;
        }
    }

    public void shoot_state_fade()
    {
        switch_shoot_state.SetActive(false);
    }
}




