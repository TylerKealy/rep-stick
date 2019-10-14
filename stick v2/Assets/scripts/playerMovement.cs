using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    public Transform THEplayer;
    public Rigidbody2D player1;
   
    public float sprint;
    public float noSwordSpeed;
    public float deceleration;
    public float acceleration;
    private Vector2 input1;

    public Transform healthBar;
    public Transform bar;
    public float playerHealth = 1;
    private double damageTaken = .03;
    public Rigidbody2D EnemyRB;
    private bool godMode;
    private bool takeDamage;


    void Start() {
        EnemyRB = gameObject.GetComponentInParent<Rigidbody2D>();
        bar = GameObject.Find("player1").GetComponent<playerMovement>().bar;


        player1 = GetComponent<Rigidbody2D>();
        healthBar= GameObject.Find("player1").transform.GetChild(1);
        bar = healthBar.transform.GetChild(0);

       
        player1.gravityScale = 0;
        player1.drag = deceleration;
    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != 0 && godMode != true && takeDamage == true)
        {
            
            playerHealth = playerHealth - (float)damageTaken;
            bar.localScale = new Vector3(playerHealth, 1f);
            if (playerHealth <= 0)
            {
                Destroy(this.gameObject);
                PlayerPrefs.SetInt("HighScore", GameObject.Find("Game Manager").GetComponent<gameManager>().highScore);
                int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);

            }
        }

        if (transform.position.x > 13.5 || transform.position.x < -16 || transform.position.y > 5.5 || transform.position.y < -13) 
        {
            Destroy(this.gameObject);
            PlayerPrefs.SetInt("HighScore", GameObject.Find("Game Manager").GetComponent<gameManager>().highScore);
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }

        

        bool leftHand1 = GameObject.Find("swordFence").GetComponent<handSwitch>().leftHand1;
        bool rightHand1 = GameObject.Find("swordFence").GetComponent<handSwitch>().rightHand1;

      
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            input1.x = Input.GetAxis("Horizontal");
            input1.y = Input.GetAxis("Vertical");
            if (leftHand1 == false && rightHand1 == false)
            {
                player1.AddForce(input1 * acceleration * noSwordSpeed * Time.deltaTime, ForceMode2D.Impulse);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player1.AddForce(input1 * acceleration * Time.deltaTime * sprint, ForceMode2D.Impulse);
            }
            else
            {
                player1.AddForce(input1 * acceleration * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
       
       

    }



    //player taking damage from enemy sword
    private void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("tag is" + coll.gameObject.tag);
        //Debug.Log("collider name is" + coll.collider.name);
        //Debug.Log("other collider name is" + coll.otherCollider.name);
        if (coll.collider.tag == "sword" && coll.collider.name == "swordFence 2" && coll.otherCollider.name == "player1")
        {
            //playerHealth = coll.gameObject.GetComponent<playerMovement>().playerHealth;
            
            //Debug.Log(bar + "123");
            //damage
            takeDamage = true;


        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.tag == "sword" && coll.collider.name == "swordFence 2" && coll.otherCollider.name == "player1")
        {
            //playerHealth = coll.gameObject.GetComponent<playerMovement>().playerHealth;
            //bar = GameObject.Find("player1").GetComponent<playerMovement>().bar;
            //Debug.Log(bar + "123");
            //damage
            takeDamage = false;


        }
    }

}
