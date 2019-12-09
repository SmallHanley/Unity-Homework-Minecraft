using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private int mode = 3;
    GameObject img;
    // Use this for initialization
    void Start () {
        transform.localPosition = new Vector3(2.17f, 1.878f, 3.363f);
        img = GameObject.Find("img");
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(mode == 1)
            {
                mode = 3;
            }
            else if(mode == 3)
            {
                mode = 1;
            }
        }
        if (mode == 3)
        {
            transform.localPosition = new Vector3(-0.06f, 1.70f, -3.17f);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            img.SetActive(false);
        }
        if(mode == 1)
        {
            transform.localPosition = new Vector3(-0.06f, 1.17f, 0.56f);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            img.SetActive(true);
        }
        if(Input.GetAxis("Mouse Y") < 0)
        {
            transform.Rotate(-(Input.GetAxis("Mouse Y")) * Time.deltaTime * 100, 0, 0);
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            transform.Rotate(-(Input.GetAxis("Mouse Y")) * Time.deltaTime * 100, 0, 0);
        }
       
    }
}
