using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMangerScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score = 0;
   private int highScore = 0;
   public int killed;
    public int padNums = 4;
    public string formattedNumber ="";
    public string formattedNumber2 ="";
    public bool hasFiredShot = false;
    // Start is called before the first frame update
    void Start()
    {
       
        highScore = PlayerPrefs.GetInt("HighScore" , highScore);
    }

    // Update is called once per frame
    void Update()
    
    {
        formattedNumber = score.ToString().PadLeft(padNums, '0');
        formattedNumber2 = highScore.ToString().PadLeft(padNums, '0');

        // Update the UI text elements
        scoreText.text = formattedNumber;
        highScoreText.text = formattedNumber2;
        



    }

    public void incScore(int points)
    {
        score = score + points;
    }
    public void highScoreCheck(int score)
    {
            
        if (this.score > highScore)
        {
            
            highScore = score;
            
            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            
            // Call Save to make sure the PlayerPrefs are saved
            PlayerPrefs.Save();

        }

    }
}
