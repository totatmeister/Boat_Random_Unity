using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// contains the mechanics the players would be doing
// such as movement, attacking, etc.
public class PlayerMechanics : MonoBehaviour {
    // private variables, basically the player's stats
    // 
    private float maxMovementSpeed;
    private readonly float minMovementSpeed = 0.1f;
    private readonly float acceleration = 0.1f;
    
    // public variables (might make the movespeed private)
    public float moveSpeed;
    public Vector2 direction;

	// Use this for initialization
	void Start () {
        maxMovementSpeed = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        // if there is an input for horizontal movement
        // make the speed when moving both vertical and horizontal slower
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            moveSpeed = Mathf.Sqrt(moveSpeed);    
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            // move the player
            MovePlayer();
        else
            moveSpeed = minMovementSpeed;
        
    }
    // moves the player to a direction based on the input (WASD keys)
    private void MovePlayer()
    {
        // accelerate the speed
        if (moveSpeed < maxMovementSpeed)
            moveSpeed += acceleration;
            
        // the direction is equal to the input direction multiplied by how long the key has been pressed and the movespeed
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime,       // x coordinate adjustment
                       Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);                 // y coordinate adjustment      
        // move the sprite towards the desired direction
        transform.Translate(direction);
    }
}
