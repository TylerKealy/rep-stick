using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteChange : MonoBehaviour
{

    //PLAYER 1 SPRITES
    public Sprite front1;
    public Sprite left1;
    public Sprite right1;
    bool leftHand1 = false;
    bool rightHand1 = false;
    //PLAYER 2 SPRITES
   // public Sprite front2;
    //public Sprite left2;
   // public Sprite right2;
   // bool leftHand2 = false;
   // bool rightHand2 = false;

    public SpriteRenderer spriteRenderer1;
   // public SpriteRenderer spriteRenderer2;

    // Use this for initialization
    void Awake()
    {
        
    }
    void Start()
    {
       
       // spriteRenderer1 = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer1.sprite == null)
        {
            spriteRenderer1.sprite = front1; // set the sprite to sprite1
        } 
    }

    void Update()
    {

        // PLAYER 1 START
        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (leftHand1 == false)
            {
                spriteRenderer1.sprite = left1; // otherwise change it back to sprite1
                leftHand1 = true;
                rightHand1 = false;
            }
            else if (leftHand1 == true)
            {
                spriteRenderer1.sprite = front1; // otherwise change it back to sprite1
                leftHand1 = false;
                rightHand1 = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {

            if (rightHand1 == false)
            {
                leftHand1 = false;
                rightHand1 = true;
                spriteRenderer1.sprite = right1; // otherwise change it back to sprite1
                //Debug.Log("one");
            }
            else if (rightHand1 == true)
            {
                //Debug.Log("two");
                spriteRenderer1.sprite = front1; // otherwise change it back to sprite1
                leftHand1 = false;
                rightHand1 = false;
            }

            //PLAYER 1 END



        

        }
    }
}