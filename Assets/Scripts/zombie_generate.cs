using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_generate : MonoBehaviour {

    public GameObject ghost;

    // Use this for initialization
    void Start () {
        
        GameObject c = Instantiate(ghost);
        c.transform.position = new Vector3(5, 0, 5);
        c.tag = "monster";
        c.AddComponent<BoxCollider>();
        c.AddComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
