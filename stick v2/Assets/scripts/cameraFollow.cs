using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform player;       //Public variable to store a reference to the player game object
    private Vector3 cameraPos;
    public float edgeSize;
    public Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
       
        
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        if (Screen.width - edgeSize < player.position.x)
        {
            Debug.Log("test");

        }
      
    }
}
