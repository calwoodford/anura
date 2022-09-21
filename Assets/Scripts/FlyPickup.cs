using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupPrefab;
    private ScoreCounter counter;
    private void Start() 
    
    {

        counter = FindObjectOfType<ScoreCounter>();
        
    }


    //Triggers the fly to disappear
    void OnTriggerEnter(Collider other){
        // If the Collider other is tagged with player then execute this code inside the curly brackets
        if (other.CompareTag("Player"))
        {
            //Adds particle effect and then destroys
            // 1 = particle effect
            // 2 = Puts it in position of fly
            // 3 = Quaternion.identity adds no rotation, because a rotation is required but I don't want to rotate.
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);

            // Helps to spawn new fly in the public variable in the other script
            FlySpawner.totalFlies --;



            // Updates score counter
            counter.UpdateScoreCounter();

            //Destroy also ends the script
            Destroy(gameObject);
        
        }
    }
}
