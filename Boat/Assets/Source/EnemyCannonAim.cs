using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this class makes the enemy's cannon aim towards the player's location
public class EnemyCannonAim : MonoBehaviour {
    // the target (player)
    public Transform targetedPlayer;
	// Use this for initialization
	void Start () {
        targetedPlayer = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        // the rotation is equal to the player's position - this object's position and the direction would be this object's 'up'
        Quaternion rotation = Quaternion.LookRotation(
            targetedPlayer.transform.position - transform.position,
            transform.TransformDirection(Vector3.down)
            );
        // rotate towards the target
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
