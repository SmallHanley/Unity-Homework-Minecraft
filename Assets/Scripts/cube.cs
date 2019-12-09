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
        /*
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0 + 2 * i; j < 30 - 2 * i; j++)
            {
                for (int k = 0 + 2 * i; k < 50 - 2 * i; k++)
                {
                    Transform c = Instantiate(dirt3);
                    int x = -10 + j;
                    int z = -15 + k;
                    c.tag = "cube2";
                    c.parent = transform;
                    c.localPosition = new Vector3(x+70, 0.5f + i, z);
                }
            }
        }
        */
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
        /*
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
        }*/
        for(int i = -20; i < 21; i++)
        {
            for(int j = -20; j < 21; j++)
            {
                Transform c = Instantiate(dirt3);
                c.tag = "cube2";
                c.parent = transform;
                c.localPosition = new Vector3(i, -0.5f, j);
                
            }
        }
        for (int k = 1; k < 6; k++)
        {
            for (int i = -20-k*3; i < 21+k*3; i++)
            {

                for (int j = -20-5*3; j < 21+5*3; j++)
                {
                    if (j  >= -15-3*k && j <= 15 + 3*k && i >= -15-3*k && i <= 15+3*k) continue;
                    else
                    {
                        Transform c = Instantiate(dirt2);
                        c.tag = "cube2";
                        c.parent = transform;
                        c.localPosition = new Vector3(i, -0.5f + k, j);
                       
                    }

                }
            }
        }
        for(int i = -70; i < 71; i++)
        {
            for(int j = -70; j < 71; j++)
            {
                if (i >= -35 && i <= 35 && j >= -35 && j <= 35) continue;
                else
                {
                    Transform c = Instantiate(dirt5);
                    c.tag = "cube2";
                    c.parent = transform;
                    c.localPosition = new Vector3(i, 4.5f, j);
                }
            }
        }
        for (int k = 0; k < 30; k++)
        {
            for (int i = 50; i < 56; i++)
            {
                for (int j = 50; j < 56; j++)
                {
                    Transform c = Instantiate(dirt1);
                    c.tag = "cube2";
                    c.parent = transform;
                    c.localPosition = new Vector3(i, 5.5f+k, j);
                }
            }
        }


        for (int k = 0; k < 10; k++)
        {
            for (int i = 15; i < 20; i++)
            {
                for (int j = 15; j < 20; j++)
                {
                    Transform c = Instantiate(dirt4);
                    c.tag = "cube2";
                    c.parent = transform;
                    c.localPosition = new Vector3(i - 50, 5.5f + k, j - 50);
                }
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
