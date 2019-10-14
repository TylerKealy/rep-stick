using UnityEngine;
using System.Collections;

public class hitDetection : MonoBehaviour
{
    public float hitSpeed;
  //  public Transform player;
   // public BoxCollider2D enemy;
    public BoxCollider2D sword;
    public Rigidbody2D EnemyRB;
    public Transform barEnemy;
    public Transform healthBarEnemy;
    public double damageTaken = .25;
    float health;
    public GameObject enemy;
    public GameObject enemyPrefab;
    private Rigidbody2D weaponRB;
    private Transform weapon;
    float rotateSpeed;
    private Vector3 angle;
    public int enemysSpawned = 1;

    //public float distanceToHit = 4;



    private void Start()
    {
        // bar = transform.Find("bar");
        //EnemyRB = GameObject.Find("enemy").GetComponent<AI>().AIrb;
        // enemy = GameObject.Find("enemy");
        

    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            //enemysSpawned += 1;
            GameObject.Find("Game Manager").GetComponent<gameManager>().enemyCount += 1;
            //Debug.Log("enemyCOUnt AFTER SPAWN is " + enemysSpawned);
            int randInt = Random.Range(-5, 5);
            Instantiate(enemyPrefab, new Vector3(randInt, 0), new Quaternion(0, 0, 0, 0));

        }









        /*
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            float yValue = hit.collider.gameObject.transform.localPosition.y;
            float xValue = hit.collider.gameObject.transform.localPosition.x;
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.tag == "enemy")
            {
                Debug.Log(player.position.y - yValue);
                Debug.Log(player.position.x - xValue);

                if ((player.position.y - yValue) <= distanceToHit && (player.position.y - yValue) >= -distanceToHit )
                {
                    if ((player.position.x - xValue) <= distanceToHit && (player.position.x - xValue) >= -distanceToHit)
                    {
                        Rigidbody2D EnemyRB = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                        EnemyRB.AddForce(transform.up * hitSpeed);
                    }

                }


            }
        }
        */

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

    
        if (coll.gameObject.tag == "enemy" && coll.collider.tag != "sword")
        {
            //damage
           
            enemy = coll.gameObject;
            //Debug.Log(enemy);
            health = enemy.GetComponent<AI>().health;
            healthBarEnemy = enemy.transform.GetChild(1);
            barEnemy = healthBarEnemy.transform.GetChild(0);
            //Debug.Log(barEnemy);
            // barEnemy = GameObject.Find("enemy").GetComponent<AI>().barEnemy;
            if (health != 0)
            {
                //Debug.Log(coll.collider.name);
                
               // health = health - (float)damageTaken;
                barEnemy.localScale = new Vector3(health, 1f);
               
            }
            

        }
        
          
        
        
        if (coll.collider.tag == "sword" && Input.GetMouseButton(0))
        {
             EnemyRB = coll.gameObject.GetComponentInParent<Rigidbody2D>();
            //Debug.Log("enemyrb is " + EnemyRB);
             EnemyRB.AddForce(transform.up * hitSpeed);
            //Debug.Log("inside the collider thing");




            /*
            weaponRB = coll.gameObject.GetComponent<Rigidbody2D>();
            enemy = coll.collider.GetComponentInParent<GameObject>();
            weapon = enemy.GetComponent<AI>().weapon;
            angle = enemy.GetComponent<AI>().angle;
            angle.z = angle.z - 90;
            rotateSpeed = 600;

            weapon.rotation = Quaternion.Slerp(weapon.rotation, Quaternion.Euler(angle), Time.deltaTime * rotateSpeed);
             weaponRB.AddForce(transform.up * hitSpeed);
             */

        }


    
    
    }


}