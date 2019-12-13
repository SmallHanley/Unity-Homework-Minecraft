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
    //private GameObject hide;
    // Use this for initialization
    void Start () {
        transform.position = new Vector3(3, 0, 0);
        tmp = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>();
        monster = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
    
        //hide = GetComponent<GameObject>();
        //agent.SetDestination(viking_position);
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
        //transform.LookAt(viking_position);
        monster_forward.updateforward(transform.forward);
        //agent.SetDestination(viking_position);
        transform.LookAt(new Vector3(viking_position.x, 0, viking_position.z));
        if (distance() > 0.5f && !sound.isPlaying) {
            animator.SetFloat("status", 1f);//walk
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
        //transform.position.x < 19 && transform.position.x > -19 && transform.position.z < 19 && transform.position.z > -19 &&
        if ( distance() > 0.5)
        {/*
            if (viking_position.x > transform.position.x)
            {
                transform.position += Time.deltaTime * moving_speed * new Vector3(1, 0, 0);
            }
            else if (viking_position.x < transform.position.x)
            {
                transform.position -= Time.deltaTime * moving_speed * new Vector3(1, 0, 0);
            }
            if (viking_position.z > transform.position.z)
            {
                transform.position += Time.deltaTime * moving_speed * new Vector3(0, 0, 1);
            }
            else if (viking_position.z < transform.position.z)
            {
                transform.position -= Time.deltaTime * moving_speed * new Vector3(0, 0, 1);
            }*/
            transform.position +=  Time.deltaTime * moving_speed * transform.forward;
            //if(project_sun.sun_y < 0)tmp = transform.position;
            //Cc.SimpleMove(Time.deltaTime * moving_speed * Ddistance(viking_position , transform.position));
            //Cc.SimpleMove((Time.deltaTime * moving_speed * transform.forward).normalized);
            //Debug.Log(transform.forward);
            //Debug.Log(transform.position);
           
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Viking_Sword")
        {

            //Debug.Log("collide monster");
        }
        if (collision.gameObject.tag == "cube2" || collision.gameObject.tag == "cube3" || collision.gameObject.tag == "cube4" || collision.gameObject.tag == "cube5" || collision.gameObject.tag == "cube1")
        {
            
            //monster.AddForce(Vector3.up * 3000);
            //Debug.Log("hit wall");
        }

    }
    


}
