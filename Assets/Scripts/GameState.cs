using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    private bool gameStarted = false;

    [SerializeField]
    private Text gameStateText;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private BirdMovement birdMovement;

    [SerializeField]
    private TargetFollow targetfollow;

    private float restartDelay = 3;

    private float restartTimer;

    private FrogMovement frogMovement;

    private PlayerHealth playerHealth;




    // Start is called before the first frame update
    void Start()
    {
        //Works with variables rather than the classes, because variables change and the class does not
        // Hides the mouse cursor for the game start
        Cursor.visible = false;

        frogMovement = player.GetComponent<FrogMovement>();

        playerHealth = player.GetComponent<PlayerHealth>();

        // Prevent the frog from moving at the start of the game
        frogMovement.enabled = false;

        //Prevent the bird from moving at the start of the game

        birdMovement.enabled = false;

        //Prevent the Target Follow from moving to it's game position
        targetFollow.enabled = false;


        
    }

    // Update is called once per frame
    void Update()
    {
        //Unity's built in input class for keys, triggers when the space bar is released 
        if(GameStarted == false && Input.GetKeyUp(KeyCode.Space))
        {
            //...Start the game
            StartGame();

        }
        // If the player is no longer alive....
        if(playerHealth.alive == false)
        //End the game
        {
            EndGame();

            //Increment a timer to count up to restart...

            restartTimer = restartTimer + Time.deltaTime;

            //And if it reaches the restart delay...
            if(restartTimer >= restartDelay)
            {
                //Then reload the currently loaded scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
    private void StartGame()
    {
        //Set the game state
        gameStarted = true;

        //Remove the start text
        gameStateText.color - Color.clear;

        // Undo the things that were set to false earlier on to stop things moving

        frogMovement.enabled = true;

        birdMovement.enabled = true;

        targetfollow.enabled = true;

    }

    private void EndGame()
    {

        //Set the game state
        gameStarted = false;

        //Show the game over text
        gameStateText.color = Color.white;
        gameStateText.text = "GameOver!";

        //Remove the frog from the game
        player.setActive(false);

    }
}
