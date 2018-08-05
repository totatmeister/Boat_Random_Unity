using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannon : MonoBehaviour {
    #region Private Variables
    // the position of the mouse
    private Vector3 mousePosition;
    
    // the list of projectiles
    private List<GameObject> projectiles = new List<GameObject>();
    
    // might change these variables to be public read private write

    // the initial speed of the projectile
    private readonly float InitialProjectileSpeed = 1.0f;

    // the change in speed for the projectile 
    private readonly float ProjectileAcceleration = 1.1f;

    // how long the projectile lasts in seconds (1.0f = 1s)
    private readonly float projectileLife = 1.0f;

    // the maximum velocity of the projectile 
    private readonly float MaxProjectileSpeed = 4.0f;
    #endregion
    public int maxNumberOfProjectile;
    public GameObject projectilePrefab;
   

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Make the sprite look/point towards the mouse/cursor
        RotateSpriteToCursor();
        // if the player clicks to shoot and the player hasn't fired the max number of projectiles
        if (Input.GetButtonDown("Fire1") && projectiles.Count < maxNumberOfProjectile)
        {
            FireProjectile();
        }
        // destroy the projectile after 1 second (to prevent having too much projectiles on the screen) if there are any projectiles
        DestroyExistingProjectiles();
    }
    /// <summary>
    /// Destroys any existing projectile based on the projectile's life
    /// </summary>
    private void DestroyExistingProjectiles()
    {
        if (projectiles.Count > 0)
        {
            foreach (var projectile in projectiles)
            {
                Object.Destroy(projectile, projectileLife);
                // if the projectile is already deleted, remove all null entries on the projectile list 
                if (projectile == null)
                {
                    // remove the null entry
                    projectiles.Remove(null);
                    // jump out of the iteration because the list has been modified
                    break;
                }
                // Accelerate the projectile's speed if it is not on the maximum speed 
                Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
                if (projectileRigidBody.velocity.magnitude < MaxProjectileSpeed)
                    projectileRigidBody.velocity = projectileRigidBody.velocity * ProjectileAcceleration;
            }
        }
    }

    /// <summary>
    /// Creates a bullet and fires it towards the mouse's position 
    /// </summary>
    private void FireProjectile()
    {
        // the direction is towards the mouse position from your current position
        Vector2 projectileDirection = mousePosition - transform.position;
        projectileDirection.Normalize();
        // instantiate the bullet
        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.velocity = InitialProjectileSpeed * projectileDirection;
        // add it to the list of projectiles
        projectiles.Add(bullet);
    }

    /// <summary>
    /// Rotates this sprite to point towards the cursor
    /// </summary>
    private void RotateSpriteToCursor()
    {
        // Side note: the 'world' heh, za warudo. Yes its a jojoke
        // get the mouse position based on the 'world' space
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // the rotation is from current position - target position
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;

        transform.eulerAngles = new Vector3(0, 0, 90 + transform.eulerAngles.z);
    }
}
