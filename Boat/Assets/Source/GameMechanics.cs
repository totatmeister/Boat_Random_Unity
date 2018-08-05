using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this keeps track of the player's location, and should keep track of other things such as score, currency, etc. in the future.
public class GameMechanics : MonoBehaviour {
    // list of enemies
    private List<GameObject> enemies = new List<GameObject>();
    // maximum number of enemies
    private readonly int maxNumberofEnemies = 1;
    // the player's location
    public Vector3 playerLocation;
    // the prefab for the enemies
    public GameObject enemyShipPrefab;
    // Use this for initialization
    void Start () {
        playerLocation = GetComponentInChildren<PlayerMechanics>().transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // keep track of the player's location
        playerLocation = GetComponentInChildren<PlayerMechanics>().transform.position;
        if(enemies.Count < maxNumberofEnemies)
        {
            GameObject enemy = Instantiate(enemyShipPrefab, playerLocation, Quaternion.identity);
            enemies.Add(enemy);
        }
    }
}
