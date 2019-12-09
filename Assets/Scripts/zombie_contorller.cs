using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_contorller : MonoBehaviour {
    Vector3 viking_position;
    string status = "";
    private float moving_speed = 5f;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(3, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(viking_position);
        
        if (transform.position.x < 19 && transform.position.x > -19 && transform.position.z < 19 && transform.position.z > -19 && distance() > 0.5)
        {
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
            }
        }
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
        if (collision.gameObject.name == "Viking_Sword") Debug.Log("collide monster");

    }


}
