using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class PlayerControl : MonoBehaviour {

    private float moveing_speed = 5f;
    private Rigidbody tr;
    private bool isGround;
    public Animator animator;
    private AudioSource sound;
    public AudioClip[] ac = new AudioClip[3];
    private Vector3 monster_forward;
    private int blood;
    CharacterController Cc;
    // Use this for initialization
    void Start () {
        tr = GetComponent<Rigidbody>();
        isGround = true;
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        transform.position = new Vector3(0, 0, 0);
        Cc = GetComponent<CharacterController>();
        blood = 10;
    }
    private zombie_contorller viking_position;
    void Awake()
    {
        viking_position = GameObject.FindObjectOfType<zombie_contorller>();
       
    }
	public void updateforward(Vector3 monster_vector)
    {
        monster_forward = monster_vector;
    }
	// Update is called once per frame
	void Update () {
        viking_position.updateposition(transform.position);
        viking_position.update_player_forward(transform.forward);
        transform.tag = "Untagged";
        animator.SetFloat("speed", 0f);
        move();
        mouse();
        jump();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Scene cur = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "monster" || collision.gameObject.tag == "ground" || collision.gameObject.tag == "cube1" || collision.gameObject.tag == "cube2" || collision.gameObject.tag == "cube3" || collision.gameObject.tag == "cube4" || collision.gameObject.tag == "cube5")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "monster")
        {
            //Debug.Log("fly");
            tr.AddForce(monster_forward * 500f);
            string heart_name = "heart" + blood.ToString();
            GameObject heart_gameobject = GameObject.Find(heart_name);
            Destroy(heart_gameobject);
            blood--;
            if(blood == 0)
            {
                Application.Quit();
            }
        }
  
    }

    void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * transform.forward;
            //Cc.Move(moveing_speed * Time.deltaTime * transform.forward);
            animator.SetFloat("speed", moveing_speed);
            transform.tag = "walk";
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= moveing_speed * Time.deltaTime * transform.forward;
            //Cc.Move(-moveing_speed * Time.deltaTime * transform.forward);
            animator.SetFloat("speed", moveing_speed);
            transform.tag = "walk";
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= moveing_speed * Time.deltaTime * transform.right;
            //Cc.Move(-moveing_speed * Time.deltaTime * transform.right);
            animator.SetFloat("speed", moveing_speed);
            transform.tag = "walk";
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * transform.right;
            //Cc.Move(moveing_speed * Time.deltaTime * transform.right);
            animator.SetFloat("speed", moveing_speed);
            transform.tag = "walk";
        }
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * transform.forward;
            animator.SetFloat("speed", moveing_speed * 2);
            transform.tag = "run";
        }
        if (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.localPosition -= moveing_speed * Time.deltaTime * transform.forward;
            animator.SetFloat("speed", moveing_speed * 2);
            transform.tag = "run";
        }
        if (Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.localPosition -= moveing_speed * Time.deltaTime * transform.right;
            animator.SetFloat("speed", moveing_speed * 2);
            transform.tag = "run";
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            transform.localPosition += moveing_speed * Time.deltaTime * transform.right;
            animator.SetFloat("speed", moveing_speed * 2);
            transform.tag = "run";
        }
        if (transform.tag == "run" && sound.isPlaying == false)
        {
            sound.clip = ac[1];
            sound.Play();
        }
        else if (transform.tag == "walk" && sound.isPlaying == false)
        {
            sound.clip = ac[2];
            sound.Play();
        }
     
    }
    
    void mouse()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(0, (Input.GetAxis("Mouse X")) * Time.deltaTime * 150, 0);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(0, (Input.GetAxis("Mouse X")) * Time.deltaTime * 150, 0);
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            tr.AddForce(Vector3.up * 300);
            sound.clip = ac[0];
            sound.Play();
            sound.loop = false;
            isGround = false;
        }
      
    }
   

}


