using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is literally useless now, but keeping in case i go back to old ways


public class hitDetectionAI : MonoBehaviour {
    public float hitSpeed;
    //public Transform player;
    // public BoxCollider2D enemy;
    //public BoxCollider2D sword;
    private Rigidbody2D EnemyRB;
    public Transform bar;
    public double damageTaken = .25;
    float health;
    private bool godMode;
    public GameObject player;
    //public GameObject enemy;

    

    // Use this for initialization
    void Start () {
       // EnemyRB = GameObject.Find("enemy").GetComponent<AI>().AIrb;
        //EnemyRB = gameObject.GetComponentInParent<Rigidbody2D>();

        //player = GameObject.Find("player1");
     
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if (Input.GetKeyDown(KeyCode.G))
        {
            godMode = true;
        }
        */
       
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
     
        /*
        if (coll.gameObject.tag == "Player" && coll.collider.name == "player1")
        {
            health = coll.gameObject.GetComponent<playerMovement>().playerHealth;
            bar = GameObject.Find("player1").GetComponent<playerMovement>().bar;
            //Debug.Log(bar + "123");
            //damage
            if (health != 0 && godMode != true)
            {
                Debug.Log(coll.collider.name);
                health = health - (float)damageTaken;
                bar.localScale = new Vector3(health, 1f);
                if (health == 0)
                {
                    Destroy(player);
                }
            }
            



        }
        
         if (coll.collider.name == "swordFence")
        {
            //EnemyRB.AddForce(transform.up * hitSpeed);
        }

    */


    }

}
