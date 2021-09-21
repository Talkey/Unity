using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    // Start is called before the first frame update
    public GameObject death;
    public AudioSource Enemy_boom;
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        Enemy_boom = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeathDestory()
    {
        GameObject de= Instantiate(death, transform.position, Quaternion.identity);
        Enemy_boom.Play();
        Destroy(de,.5f);
        Destroy(gameObject,.5f);
    }

}
