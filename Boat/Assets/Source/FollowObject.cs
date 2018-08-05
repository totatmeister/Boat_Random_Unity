using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
    public GameObject followedObject;
    private Vector3 targetPosition;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // go to the targeted position which is the x and y of the player, and the current z of the camera
        targetPosition = new Vector3(followedObject.transform.position.x, followedObject.transform.position.y, transform.position.z);
        // make this object(camera) follow closely to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed*Time.deltaTime);
    }
}
