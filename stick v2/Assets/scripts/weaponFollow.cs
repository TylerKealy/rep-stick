using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class weaponFollow : MonoBehaviour {
    bool rightHand;
    bool leftHand;
 
    // public Transform ignoreMe;
    // Use this for initialization
    void Start () {
       
    }

    // Update is called once per frame
    void Update()
    {
        bool leftHand = GameObject.Find("swordFence").GetComponent<handSwitch>().leftHand1;
        bool rightHand = GameObject.Find("swordFence").GetComponent<handSwitch>().rightHand1;
        if (rightHand == true || leftHand == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            //float angle = Mathf.Atan2(Input.mousePosition.y - transform.position.y, Input.mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
        //rotation
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player1")
        {
           // Physics.IgnoreCollision(ignoreMe.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
        /*
        Camera cam;
        Transform my;
        Rigidbody2D body;


        void Awake()
        {
            cam = Camera.main;
            my = GetComponent<Transform>();
            body = GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            // Distance from camera to object.  We need this to get the proper calculation.
            float camDis = cam.transform.position.y - my.position.y;

            // Get the mouse position in world space. Using camDis for the Z axis.
            Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

            float AngleRad = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x);
            float angle = (180 / Mathf.PI) * AngleRad;

            body.rotation = angle;
        }
        */
    }

