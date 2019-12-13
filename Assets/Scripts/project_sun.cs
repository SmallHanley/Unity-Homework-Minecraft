using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class project_sun : MonoBehaviour {
    public zombie_contorller zombie;
    // Use this for initialization
    void Start () {
        zombie = GameObject.FindObjectOfType<zombie_contorller>();
    }
    static public float sun_x, sun_y, sun_z;
    // Update is called once per frame
    void Update () {
        if (transform.position.y < 0) zombie.revive();
        sun_x = transform.position.x;
        sun_y = transform.position.y;
        sun_z = transform.position.z;
        
        transform.LookAt(Vector3.zero);
        transform.RotateAround(Vector3.zero, Vector3.right, Time.deltaTime * 5f);
	}
}
