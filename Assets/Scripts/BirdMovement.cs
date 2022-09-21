using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BirdMovement : MonoBehaviour
{
    [SerializeField]
    private Transform frogTransform;

    private NavMeshAgent birdAgent;

    private Animator _birdAnimator;


    // Start is called before the first frame update
    void Start()
    {
        birdAgent = GetComponent<NavMeshAgent>();
        _birdAnimator = GetComponent<Animator>();

        //Makes the bird walk.
        _birdAnimator.SetBool("Walking", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tells the bird where the frog is every frame and moves it there.
        birdAgent.SetDestination(frogTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _birdAnimator.SetBool("Attacking", true);
        }

    }
}
