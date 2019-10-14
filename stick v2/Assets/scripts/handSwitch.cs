using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handSwitch : MonoBehaviour {

    public bool rightHand1;
    public bool leftHand1;
    public bool rightHand2;
    public bool leftHand2;
    bool e;
    bool q;
    public Transform sword1;
    private Rigidbody2D playerSwordRB;
    private BoxCollider2D swordBoxCollider;
    


    private float yPosition;
    private SpriteRenderer swordSprite;
    // Use this for initialization
    void Start() {

        playerSwordRB = gameObject.GetComponent<Rigidbody2D>();
        swordBoxCollider = gameObject.GetComponent<BoxCollider2D>();
        swordSprite = GetComponent<SpriteRenderer>();
        rightHand1 = false;
        leftHand1 = false;
        rightHand2 = false;
        leftHand2 = false;

        playerSwordRB.isKinematic = true;
        playerSwordRB.velocity = new Vector2(0, 0);
        swordBoxCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            q = true;
            e = false;
            //Debug.Log("Keydown");
            //swordSprite.sortingLayerID = 1;

            // Debug.Log("lefthand is" + leftHand);
            //  Debug.Log("righthand is" + rightHand);
            if (leftHand1 == false)
            {
                //enabled
                playerSwordRB.isKinematic = false;
                playerSwordRB.freezeRotation = false;
                swordBoxCollider.enabled = true;


                leftHand1 = true;
                rightHand1 = false;
                // float xPosition = sword.localPosition.x - 3.04f;
                float y = (float).4;
                float z = (float).36;
                sword1.localPosition = new Vector3(-1, y, z);
            }
            else if (leftHand1 == true)
            {
                playerSwordRB.isKinematic = true;
                playerSwordRB.freezeRotation = true;
                playerSwordRB.velocity = new Vector2(0,0);
                swordBoxCollider.enabled = false;


                rightHand1 = false;
                leftHand1 = false;
                //swordSprite.sortingLayerID = 0;
                float x = (float)-0.542;
                float y = (float)-0.055;
                float z = (float)0.3691406;
                sword1.localPosition = new Vector3(x, y, z);
                sword1.eulerAngles = new Vector3(0, 0, -60);

            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            e = true;
            q = false;
            //Debug.Log("Keydown");
            // swordSprite.sortingLayerID = 1;
            if (rightHand1 == false)
            {
                playerSwordRB.isKinematic = false;
                swordBoxCollider.enabled = true;
                playerSwordRB.freezeRotation = false;

                rightHand1 = true;
                leftHand1 = false;
                float y = (float).418;
                //float xPosition = sword.localPosition.x + 3.04f;
                sword1.localPosition = new Vector3(1, y, 0);
            }
            else if (rightHand1 == true)
            {

                playerSwordRB.isKinematic = true;
                swordBoxCollider.enabled = false;
                playerSwordRB.velocity = new Vector2(0, 0);
                playerSwordRB.freezeRotation = true;

                rightHand1 = false;
                leftHand1 = false;
                // swordSprite.sortingLayerID = 0;
                float x = (float)-0.542;
                float y = (float)-0.055;
                float z = (float)0.3691406;
                sword1.localPosition = new Vector3(x, y, z);
                sword1.eulerAngles = new Vector3(0, 0, -60);

            }
        }
        else if (rightHand1 == true)
        {
            playerSwordRB.isKinematic = false;
            swordBoxCollider.enabled = true;
            playerSwordRB.freezeRotation = false;

            rightHand1 = true;
            leftHand1 = false;
            float y = (float).418;
            //float xPosition = sword.localPosition.x + 3.04f;
            sword1.localPosition = new Vector3(1, y, 0);
        }
        else if (leftHand1 == true)
        {
            playerSwordRB.isKinematic = false;
            swordBoxCollider.enabled = true;
            playerSwordRB.freezeRotation = false;

            leftHand1 = true;
            rightHand1 = false;
            // float xPosition = sword.localPosition.x - 3.04f;
            float y = (float).4;
            float z = (float).36;
            sword1.localPosition = new Vector3(-1, y, z);
        }
       
        else if (Input.GetKeyDown(KeyCode.J))
        {
           
        }
        
    }
}
