using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows 'Text' because it's from Unity
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour
{
    // Tracks score
    public static int score;
    private Text scoreCounterText;


    // Start is called before the first frame update
    void Start()
    {
        // Retrieves the text from the Unity file
        scoreCounterText = GetComponent<Text>();
        
    }
    public void UpdateScoreCounter()

    //Updates the score counter, but only when the fly is destroyed, not every frame.
    {
        score++;

        scoreCounterText.text = score.ToString() + " Flies";


    }
}
