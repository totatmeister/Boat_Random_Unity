using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotate : MonoBehaviour {
    // Use this for initialization
    private readonly int ROTATIONSPEED = 10;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // get the direction of where the ship is moving based on the player's movement script
        Vector2 moveDirection = GetComponentInParent<PlayerMechanics>().direction;
        // if the ship is moving
        if (moveDirection != Vector2.zero)
        {
            // the current rotation of the sprite/ship
            Quaternion baseRotation = transform.rotation;
            // the desired rotation based on the movement
            Quaternion desiredRotation;

            // calculate the angle on where it is moving 
            // get the arctangent of the y/x to get the angle of the direction you are going towards
            // convert it to degrees
            // add 90 because the ship sprite is by default pointing downwards 
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 90;
            // set that as the desired rotation
            desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // rotate the ship from the current rotation to the desired rotation
            transform.rotation = Quaternion.RotateTowards(baseRotation, desiredRotation, ROTATIONSPEED);
        }
    }
}
