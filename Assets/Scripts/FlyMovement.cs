using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyMovement : MonoBehaviour
{
    [SerializeField]    
    // Every frame rotates around the x value -1
        private Transform center;
        private float flySpeed;


    // Start is called before the first frame update
    void Start()
    {
    // Chooses a random value between 300(float) and 700(float) to make each rotation have a different speed.
    flySpeed = Random.Range(300f, 700f);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime is the time between this frame and the last frame - why does this need to be there rather than just using the flySpeed variable?
        transform.RotateAround(center.position, Vector3.up, flySpeed * Time.deltaTime);
    }
}
