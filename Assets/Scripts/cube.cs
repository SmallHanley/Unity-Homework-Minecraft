using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

    public Transform dirt1;
    public Transform dirt2;
    public Transform dirt3;
    public Transform dirt4;
    public Transform dirt5;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0 + 2 * i; j < 30 - 2 * i; j++)
            {
                for (int k = 0 + 2 * i; k < 50 - 2 * i; k++)
                {
                    Transform c = Instantiate(dirt2);
                    int x = -10 + j;
                    int z = -15 + k;
                    c.tag = "cube2";
                    c.parent = transform;
                    c.localPosition = new Vector3(x, 0.5f + i, z);
                }
            }
        }
        /*for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                Transform c = Instantiate(dirt2);
                int x = -10 + i;
                int z = -15 + j;
                c.tag = "cube";
                c.parent = transform;
                c.localPosition = new Vector3(x, 1.5f, z);
            }
        }*/
        //16-0.5 28
        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Transform c = Instantiate(dirt1);
                c.tag = "cube1";
                c.parent = transform;
                c.localPosition = new Vector3(i+20, -0.5f, j-28);
            }
        }
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Transform c = Instantiate(dirt3);
                c.tag = "cube3";
                c.parent = transform;
                c.localPosition = new Vector3(i + 16, -1.5f, j - 28);
            }
        }
        //14 -1.5 -48
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Transform c = Instantiate(dirt4);
                c.tag = "cube4";
                c.parent = transform;
                c.localPosition = new Vector3(i + 14, -0.5f, j - 48);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
