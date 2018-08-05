using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    private float minDistanceFromPlayer = 1.0f;
    private float maxDistanceFromPlayer = 3.0f;
    private float moveSpeed = 2.0f;
    private float delayToMove = 0.3f;
    public Transform targetedPlayer;

    // Use this for initialization
    void Start () {
        targetedPlayer = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        // if the distance is between the max and the minimum, attack the player
		if(Vector3.Distance(targetedPlayer.position, transform.position) < maxDistanceFromPlayer && Vector3.Distance(targetedPlayer.position, transform.position) > minDistanceFromPlayer)
        {

        }
        // if the distance is smaller than the minimum, move away from the player
        else if(Vector3.Distance(targetedPlayer.position, transform.position) < minDistanceFromPlayer)
        {
            // TODO: fix logic for moving away from player

            // look towards the player
            transform.LookAt(targetedPlayer.position);
            // rotate Y back to 0 (it rotates to 90 degrees for some reason)
            transform.Rotate(new Vector3(0, -90, 180), Space.Self);
            // move away from the player
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime* Random.Range(1.0f, 2.0f), 0), Space.World);
        }
        // if not, then move towards the player
        else
        {
            // look towards the player
            transform.LookAt(targetedPlayer.position);
            // rotate Y back to 0 (it rotates to 90 degrees for some reason)
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            // move towards the player
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0), Space.Self);
        }
	}
}
