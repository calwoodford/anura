using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public bool alive;
    [SerializeField]
    private GameObject pickupPrefab;


    // Start is called before the first frame update
    void Start()

    {
                alive = true;
        
    }
    void OnTriggerEnter(Collider other)
    {
        // If there's a collision with an enemy and the player is alive the code is executed.
        if(other.CompareTag("Enemy") && alive == true)
        {
            alive = false;
            //Create the pickup particles
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);

        }
    }

}
