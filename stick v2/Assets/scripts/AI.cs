using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

  
    public Transform target;
    public Transform weapon;
    public Rigidbody2D AIrb;
    public float accel;
    public float noSwordSpeed;
    public float sprint;
    private Vector2 input1;
    public Transform healthBarEnemy;
    public Transform barEnemy;
    private double damageTaken = .05;
    


    private bool leftHand;
    private bool rightHand;
    public SpriteRenderer aiSriteRenderer;
    public Sprite left;
    public Sprite right;
    public Sprite front;
    public float health = 1;
    private bool noSword;
    private float rotateSpeed;
    public Vector3 angle;
    private GameObject sword;
    private bool takeDamage;
    public int points = 0;
    public int enemysKilled = 0;

    Rigidbody2D enemyRb;
     

   public float deceleration;
   
   //int MaxDist = 10000;
   // double MinDist = .5;


    void Start()
    {

        
        AIrb = this.GetComponent<Rigidbody2D>();
        healthBarEnemy = transform.GetChild(1);
        //healthBarEnemy = GameObject.Find("enemy").transform.GetChild(1);
        barEnemy = healthBarEnemy.transform.GetChild(0);
        target = GameObject.Find("player1").transform;
        weapon = transform.GetChild(0); 
        //Debug.Log(weapon);


        //Debug.Log(barEnemy.name);

        // bool leftHand1 = GameObject.Find("swordFence").GetComponent<handSwitch>().leftHand1;

        //target = transform.Find("player1");

        AIrb.gravityScale = 0;
        AIrb.drag = deceleration;

        if (aiSriteRenderer.sprite == null)
        {
            aiSriteRenderer.sprite = front; // set the sprite to sprite1
        }
    }

    void Update()
    {
        


        if (takeDamage)
        {
            health = health - (float)damageTaken;
            //Debug.Log("health is " + health);
            barEnemy.localScale = new Vector3(health, 1f);
            if (health <= 0)
            {
                
                GameObject.Find("Game Manager").GetComponent<gameManager>().enemyCount -= 1;
                //enemysKilled += 1;
                // Debug.Log("enemysKilled is " + enemysKilled);
                if (GameObject.Find("Game Manager").GetComponent<gameManager>().enemyCount >= 1 && GameObject.Find("Game Manager").GetComponent<gameManager>().enemyCount < 5)
                {
                    GameObject.Find("Game Manager").GetComponent<gameManager>().Points += 2 * GameObject.Find("Game Manager").GetComponent<gameManager>().enemyCount;
                }
                else if (GameObject.Find("Game Manager").GetComponent<gameManager>().enemyCount >= 5)
                {
                    GameObject.Find("Game Manager").GetComponent<gameManager>().Points += 3 * GameObject.Find("Game Manager").GetComponent<gameManager>().enemyCount;
                }
                else
                {
                    GameObject.Find("Game Manager").GetComponent<gameManager>().Points += 1;
                }
                


                Destroy(this.gameObject);
                

            }
        }


        if (noSword == false)
        {

            Vector3 anglePos;
        Vector3 AiPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 targetPos = Camera.main.WorldToScreenPoint(target.position);
        anglePos.x = targetPos.x - AiPos.x;
        anglePos.y = targetPos.y - AiPos.y;
            
        float angleFloat = Mathf.Atan2(anglePos.y, anglePos.x) * Mathf.Rad2Deg;
            rotateSpeed = 4;
            angle = new Vector3(0, 0, angleFloat - 90);
            weapon.rotation = Quaternion.Slerp(weapon.rotation, Quaternion.Euler(angle), Time.deltaTime * rotateSpeed);
            //weapon.rotation = Quaternion.Euler(angle);
        }
       

        RaycastHit2D hit = Physics2D.Raycast(target.position, Vector2.zero);

        // Cast a ray straight down.
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);

        // If it hits something...
        if (hit.collider != null)
        {
            // Debug.Log("raycast hit "+  hit.collider.name);








            if (transform.position.x != target.position.x + 5 || transform.position.y != target.position.y + 5 || transform.position.z != target.position.z + 5)
                {
                    //Debug.Log("target pos is " + target.position);
                    //Debug.Log("target pos is " + target.position);
                   // Debug.Log("AI pos is " + transform.position);

                   
                    
                if (transform.position.x - target.position.x > 6 || transform.position.x - target.position.x < -6)
                {
                    noSword = true;
                    leftHand = false;
                    rightHand = false;
                    aiSriteRenderer.sprite = front;

                    float x = (float).74;
                    float y = (float).06;
                    float z = (float).00;
                    weapon.localPosition = new Vector3(-x, -y, z);
                    
                     x = (float)0;
                     y = (float)0;
                    z = (float)60;
                    angle = new Vector3(x, y, -z);
                    weapon.rotation = Quaternion.Euler(angle);
                    

                    transform.position += (target.position - transform.position).normalized * noSwordSpeed * Time.deltaTime;
                }
                else if (transform.position.x - target.position.x >= 2.75 || transform.position.x - target.position.x <= -2.75 || transform.position.y - target.position.y >= .25 || transform.position.y - target.position.y <= -.25)
                {
                    noSword = false;
                    transform.position += (target.position - transform.position).normalized * accel * Time.deltaTime;
                }
            }



            if (transform.position.x - target.position.x > 0 && noSword == false)
            {
                leftHand = true;
                rightHand = false;
                aiSriteRenderer.sprite = left;

                // float xPosition = sword.localPosition.x - 3.04f;
                float x = (float)1.2;
                float y = (float).4;
                    float z = (float).36;
                    weapon.localPosition = new Vector3(-x, y, z);
                
            }
            else if(transform.position.x - target.position.x < 0 && noSword == false)
            {
                leftHand = false;
                rightHand = true;
                aiSriteRenderer.sprite = right;

                float y = (float).57;
                float x = (float)1.31;

                weapon.localPosition = new Vector3(x, y, 0);
            }
                

                
                 




            }





    }
    IEnumerator Example()
    {
       
        yield return new WaitForSeconds(1);
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.name == "swordFence" && coll.collider.tag == "sword" && coll.otherCollider.tag == "enemy")
        {
           sword = coll.collider.gameObject;
           
            if(sword.GetComponent<handSwitch>().leftHand1 == false && sword.GetComponent<handSwitch>().rightHand1 != false || sword.GetComponent<handSwitch>().leftHand1 != false && sword.GetComponent<handSwitch>().rightHand1 == false)
            {
                //Debug.Log(health);
                takeDamage = true;
            }
            
        }
            

    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.name == "swordFence" && coll.collider.tag == "sword")
        {
            takeDamage = false;
        }
        else
        {
            //Debug.Log("test       " + coll.collider.name);
            //Debug.Log(coll.collider.tag);
        }
    }


    

}

