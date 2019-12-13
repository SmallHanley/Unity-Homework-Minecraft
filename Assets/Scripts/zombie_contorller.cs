using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class zombie_contorller : MonoBehaviour {
    Vector3 viking_position;
   
    private float moving_speed = 3f;
    Animator animator;
    Rigidbody monster;
    private bool check_collide;
    private AudioSource sound;
    public AudioClip[] bc = new AudioClip[2];
    bool check_day = false;
    
    private PlayerControl monster_forward;
    private Vector3 player_forward;
    Vector3 tmp;
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(3, 0, 0);
        tmp = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>();
        monster = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    }
    public void revive()
    {
        transform.gameObject.SetActive(true);
    }
    void Awake()
    {
        monster_forward = GameObject.FindObjectOfType<PlayerControl>();
    }
    public void update_player_forward(Vector3 upf)
    {
        player_forward = upf;
    }
    public void attack_force()
    {
        if(distance() < 5f)monster.AddForce(player_forward * 500f);
    }
    void generator()
    {
        if (project_sun.sun_y < 0)
        {
            check_day = true;
        }
        else
        {
            check_day = false;
            transform.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void FixedUpdate() {
        generator();
        monster_forward.updateforward(transform.forward);
        transform.LookAt(new Vector3(viking_position.x, 0, viking_position.z));
        if (distance() > 0.5f && !sound.isPlaying) {
            animator.SetFloat("status", 1f);
            sound.clip = bc[0];
            sound.Play();
        }
        
        if (distance() < 2)
        {
            if (!sound.isPlaying)
            {
                sound.clip = bc[1];
                sound.Play();
            }
            animator.SetFloat("status", 3f);
        }
        if ( distance() > 0.5)
        {
            transform.position +=  Time.deltaTime * moving_speed * transform.forward;
        }  
    }
    private Vector3 Ddistance(Vector3 a, Vector3 b)
    {
        return b - a;
    }
    public void updateposition(Vector3 p)
    {
        viking_position = p;
    }
    float distance()
    {
        return Mathf.Abs(Vector3.Distance( transform.position , viking_position));
    }
}
