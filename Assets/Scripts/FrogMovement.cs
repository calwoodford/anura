using System.Threading;
using System.Numerics;
// Double check all comments to make sure I'm understanding everything correctly 
// Remember to play about with the box collider thing - only moves forard when it is turned off?
// Need to do more research into how quaternions work

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
   // The horizontal and vertical are referring to the ground plane graph, vertical is forward and horizontal is side to side. 
    private float horizontalMovement;
 

    private float verticalMovement;

    // A vector using three parameters.
    private UnityEngine.Vector3 desiredDirection;

    
    // Connects to the animator controller in Unity. 
    private Animator frogAnimator;

    private Rigidbody frogRigidBody;

    // SerializeField exposes private variables in the Unity Inspector so they can be used (like turnSpeed)
    [SerializeField]private float turnSpeed;


  // Start is called before the first frame update, initialises the game.
    void Start()
  
    // Gathers the animator component from the frog object.
    {
        frogAnimator = GetComponent<Animator>();
        frogRigidBody = GetComponent<Rigidbody>();
        frogAnimator.SetBool("IsIdle", true);

    }

    
    void Update()
    // Update is called once per frame
    // Gathers the input from the player.

    {
        // Gets the controller information from Unity and stores it in a variable, in this case it is a and d for horizontal movement.
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        // Gets the controller information from Unity and stores it in a variable, in this case it is w and s for vertical movement.
        verticalMovement = Input.GetAxisRaw("Vertical");
        
        // Our three parameter vector, the second parameter is set to 0 because the frog will not be moving up and down.
        desiredDirection = new UnityEngine.Vector3(horizontalMovement, 0, verticalMovement);
        
    }

    
    // Fixed Update as well as the normal update void because fixed update is used for physics and needs to be checked less often. Checking the physics every frame will use a lot of computing power.
    void FixedUpdate()
    {
        
       // If there desired direction is zero.
        if(desiredDirection == UnityEngine.Vector3.zero)
        

        {
             // If no buttons are being pressed, then the idle animation will play.
            frogAnimator.SetBool("IsIdle", true);

        }
        else
        {
            
            //Moves frog into new direction and makes it hop into that direction.

            //Calculates the rotation (quaternion = rotation amount)
            UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(desiredDirection, UnityEngine.Vector3.up);

            // Calculates another rotation that will rotate frog from its current rotation to target rotation over a certain period of time - like a gradient
            UnityEngine.Quaternion newRotation = UnityEngine.Quaternion.Lerp(frogRigidBody.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);

            // Moves the actual frog model in the value of the quaternion.
            frogRigidBody.MoveRotation(targetRotation);



            // Else, sets the idle parameter to false, which means the idle animation will not play, that will kick the animation into the Frog Hop phase.
            frogAnimator.SetBool("IsIdle", false);
            
        }
        
    }
}
