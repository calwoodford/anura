using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject flyPrefab;

    [SerializeField]
    //Number of flies in game
    private int totalFlyMinimum = 12;
    //Area of ground where flies can spawn (25 in x and z)

    [SerializeField]
    private float spawnArea = 25f;
    // Start is called before the first frame update
    // public static allows all other scripts to change the value.
    public static int totalFlies;

    void Start() {
    totalFlies = 0;
    
        
    }

    // Update is called once per frame
    void Update()
    {
        // While the total number of flies is less than the minimum
        while(totalFlies < totalFlyMinimum)
        {
            totalFlies ++; 

            //Create a random position for a fly
            float positionX = Random.Range(-spawnArea, spawnArea);
            float positionZ = Random.Range(-spawnArea, spawnArea);

            Vector3 flyPosition = new Vector3(positionX, 2f, positionZ);

            //Create a new fly
            Instantiate(flyPrefab, flyPosition, Quaternion.identity);
        }
    }
}
