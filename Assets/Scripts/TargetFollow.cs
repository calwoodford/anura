using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour

//[SerializrField] opens up those properties in the Unity Inspector.
{
    [SerializeField]
    // Where the target (frog) is 
    private Transform target;

    [SerializeField]
    // How far away from it
    private Vector3 offset;

    [SerializeField]
    // The speed the camera moves
    private float followSpeed;

    // Start is called before the first frame update

    // Update last after all other updates have taken place, it needs to be the last thing to react to what has happened in the game
    void LateUpdate()
    {

        Vector3 newPosition = target.position + offset;
        // Lerp = linear interpolation
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
        
    }
}
