using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class masaPlayerController : MonoBehaviour {

    //gets boat position for the player to rotate around
    public Transform ship;
    private Vector3 shipPos;
    private float rot_z;

    

    public float speed;
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Roates player to mimic being pulled by boat
        shipPos = ship.transform.position - transform.position;
        shipPos.Normalize();

        rot_z = Mathf.Atan2(shipPos.y, shipPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

       
        //Moves player
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.velocity = movement * speed;
	}

    
}
