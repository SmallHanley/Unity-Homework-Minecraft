using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cube_mouse : MonoBehaviour {

    public GameObject dirt1;
    public GameObject dirt2;
    public GameObject dirt3;
    public GameObject dirt4;
    public GameObject dirt5;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public RectTransform white;
    GameObject cube;
    private int mode;
    zombie_contorller zombie;
    // Use this for initialization
    void Start () {
        mode = 1;
	}
    void Awake()
    {
      zombie  = GameObject.FindObjectOfType<zombie_contorller>();
    }
	
	// Update is called once per frame
	void Update () {
        key_input();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycashit;
            if (Physics.Raycast(ray, out raycashit))
            {
                if (raycashit.transform.tag == "cube1" || raycashit.transform.tag == "cube2" || raycashit.transform.tag == "cube3" || raycashit.transform.tag == "cube4" || raycashit.transform.tag == "cube5")
                {
                    if(raycashit.transform.tag == "cube1")
                    {
                        text1.text = (int.Parse(text1.text) + 1).ToString();
                    }
                    else if (raycashit.transform.tag == "cube2")
                    {
                        text2.text = (int.Parse(text2.text) + 1).ToString();
                    }
                    else if (raycashit.transform.tag == "cube3")
                    {
                        text3.text = (int.Parse(text3.text) + 1).ToString();
                    }
                    else if (raycashit.transform.tag == "cube4")
                    {
                        text4.text = (int.Parse(text4.text) + 1).ToString();
                    }
                    else if (raycashit.transform.tag == "cube5")
                    {
                        text5.text = (int.Parse(text5.text) + 1).ToString();
                    }
                    Destroy(raycashit.collider.gameObject);
                }

                if (raycashit.collider.gameObject.tag == "monster")
                {
                    Debug.Log("attack monster");
                    zombie.attack_force();
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycashit;
            if (Physics.Raycast(ray, out raycashit))
            {
                if (raycashit.collider.gameObject.tag == "cube1" || raycashit.collider.gameObject.tag == "cube2" || raycashit.collider.gameObject.tag == "cube3" || raycashit.collider.gameObject.tag == "cube4" || raycashit.collider.gameObject.tag == "cube5")
                {
                    if(mode == 1)
                    {
                        if(int.Parse(text1.text) <= 0)
                        {
                            return;
                        }
                        text1.text = (int.Parse(text1.text) - 1).ToString();
                    }
                    if (mode == 2)
                    {
                        if (int.Parse(text2.text) <= 0)
                        {
                            return;
                        }
                        text2.text = (int.Parse(text2.text) - 1).ToString();
                    }
                    if (mode == 3)
                    {
                        if (int.Parse(text3.text) <= 0)
                        {
                            return;
                        }
                        text3.text = (int.Parse(text3.text) - 1).ToString();
                    }
                    if (mode == 4)
                    {
                        if (int.Parse(text4.text) <= 0)
                        {
                            return;
                        }
                        text4.text = (int.Parse(text4.text) - 1).ToString();
                    }
                    if (mode == 5)
                    {
                        if (int.Parse(text5.text) <= 0)
                        {
                            return;
                        }
                        text5.text = (int.Parse(text5.text) - 1).ToString();
                    }
                    init_cube();
                    float x = 0;
                    float y = 0;
                    float z = 0;
                    if (raycashit.point.x <= raycashit.collider.gameObject.transform.position.x + cube.transform.localScale.x / 2 + 0.00001 && raycashit.point.x >= raycashit.collider.gameObject.transform.position.x + cube.transform.localScale.x / 2 - 0.00001)
                    {
                        x = raycashit.collider.gameObject.transform.position.x + cube.transform.localScale.x;
                        y = raycashit.collider.gameObject.transform.position.y;
                        z = raycashit.collider.gameObject.transform.position.z;
                    }
                    else if(raycashit.point.x <= raycashit.collider.gameObject.transform.position.x - cube.transform.localScale.x / 2 + 0.00001 && raycashit.point.x >= raycashit.collider.gameObject.transform.position.x - cube.transform.localScale.x / 2 - 0.00001)
                    {
                        x = raycashit.collider.gameObject.transform.position.x - cube.transform.localScale.x;
                        y = raycashit.collider.gameObject.transform.position.y;
                        z = raycashit.collider.gameObject.transform.position.z;
                    }
                    else if (raycashit.point.y <= raycashit.collider.gameObject.transform.position.y + cube.transform.localScale.y / 2 + 0.00001 && raycashit.point.y >= raycashit.collider.gameObject.transform.position.y + cube.transform.localScale.y / 2 - 0.00001)
                    {
                        x = raycashit.collider.gameObject.transform.position.x;
                        y = raycashit.collider.gameObject.transform.position.y + cube.transform.localScale.y;
                        z = raycashit.collider.gameObject.transform.position.z;
                    }
                    else if (raycashit.point.y <= raycashit.collider.gameObject.transform.position.y - cube.transform.localScale.y / 2 + 0.00001 && raycashit.point.y >= raycashit.collider.gameObject.transform.position.y - cube.transform.localScale.y / 2 - 0.00001)
                    {
                        x = raycashit.collider.gameObject.transform.position.x;
                        y = raycashit.collider.gameObject.transform.position.y - cube.transform.localScale.y;
                        z = raycashit.collider.gameObject.transform.position.z;
                    }
                    else if (raycashit.point.z <= raycashit.collider.gameObject.transform.position.z + cube.transform.localScale.z / 2 + 0.00001 && raycashit.point.z >= raycashit.collider.gameObject.transform.position.z + cube.transform.localScale.z / 2 - 0.00001)
                    {
                        x = raycashit.collider.gameObject.transform.position.x;
                        y = raycashit.collider.gameObject.transform.position.y;
                        z = raycashit.collider.gameObject.transform.position.z + cube.transform.localScale.z;
                    }
                    else if (raycashit.point.z <= raycashit.collider.gameObject.transform.position.z - cube.transform.localScale.z / 2 + 0.00001 && raycashit.point.z >= raycashit.collider.gameObject.transform.position.z - cube.transform.localScale.z / 2 - 0.00001)
                    {
                        x = raycashit.collider.gameObject.transform.position.x;
                        y = raycashit.collider.gameObject.transform.position.y;
                        z = raycashit.collider.gameObject.transform.position.z - cube.transform.localScale.z;
                    }
                    cube.transform.position = new Vector3(x, y, z);


                }
                if (raycashit.collider.gameObject.tag == "ground")
                {
                    if (mode == 1)
                    {
                        if (int.Parse(text1.text) <= 0)
                        {
                            Debug.Log("1");
                            return;
                        }
                        text1.text = (int.Parse(text1.text) - 1).ToString();
                    }
                    if (mode == 2)
                    {
                        if (int.Parse(text2.text) <= 0)
                        {
                            return;
                        }
                        text2.text = (int.Parse(text2.text) - 1).ToString();
                    }
                    if (mode == 3)
                    {
                        if (int.Parse(text3.text) <= 0)
                        {
                            return;
                        }
                        text3.text = (int.Parse(text3.text) - 1).ToString();
                    }
                    if (mode == 4)
                    {
                        if (int.Parse(text4.text) <= 0)
                        {
                            return;
                        }
                        text4.text = (int.Parse(text4.text) - 1).ToString();
                    }
                    if (mode == 5)
                    {
                        if (int.Parse(text5.text) <= 0)
                        {
                            return;
                        }
                        text5.text = (int.Parse(text5.text) - 1).ToString();
                    }
                    init_cube();
                    float x = Mathf.Floor(raycashit.point.x);
                    float y = Mathf.Floor(raycashit.point.y) + cube.transform.localScale.y / 2;
                    float z = Mathf.Floor(raycashit.point.z);
                    cube.transform.position = new Vector3(x, y, z);
                }
            }
        }
    }

    void key_input()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mode = 1;
            white.localPosition = new Vector3(-400.13f, -490f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mode = 2;
            white.localPosition = new Vector3(-300.2f, -490f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mode = 3;
            white.localPosition = new Vector3(-199.7f, -490f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mode = 4;
            white.localPosition = new Vector3(-99.9f, -490f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mode = 5;
            white.localPosition = new Vector3(-0.2f, -490f, 0f);
        }
    }

    void init_cube()
    {
        switch (mode)
        {
            case 1:
                cube = Instantiate(dirt1);
                cube.tag = "cube1";
                break;
            case 2:
                cube = Instantiate(dirt2);
                cube.tag = "cube2";
                break;
            case 3:
                cube = Instantiate(dirt3);
                cube.tag = "cube3";
                break;
            case 4:
                cube = Instantiate(dirt4);
                cube.tag = "cube4";
                break;
            case 5:
                cube = Instantiate(dirt5);
                cube.tag = "cube5";
                break;
        }
    }
}
