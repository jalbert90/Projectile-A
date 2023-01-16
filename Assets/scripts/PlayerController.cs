using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the player moves
    public GameObject projectilePrefab; // A reference to the projectile prefab
    public float projectileSpeed = 5f; // The speed at which the projectile moves

    void Update()
    {
        // Get input from the user

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = new Vector3(hor, ver).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;


        // Check if the player pressed the left mouse button
        if (Input.GetMouseButtonDown(0)) // The Left button is 0 for Input.GetMouseButtonDown() function 
        {
            // If the player pressed the left mouse button, create and shoot a projectile 
            Vector3 shotDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            shotDirection.z = 0;
            shotDirection.Normalize();
            var v = shotDirection * projectileSpeed;
            //v.z = 0;

            var ProjectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            ProjectileInstance.GetComponent<Rigidbody2D>().velocity = v;
        }
    }
}