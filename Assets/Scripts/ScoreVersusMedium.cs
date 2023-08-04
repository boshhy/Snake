using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreVersusMedium : MonoBehaviour
{
    public TextCurrentScore playerOneCurrentScore;
    public TextCurrentScore playerTwoCurrentScore;
    public TextMeshProUGUI highScoreText;
    public int playerOneFoodCount = 0;
    public int playerTwoFoodCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        FoodVersus.onFoodCollectedByPlayerOne += IncreasePlayerOneScore;
        FoodVersus.onFoodCollectedByPlayerTwo += IncreasePlayerTwoScore;

        VersusSnakeControllerPlayerOne.onDeath += ResetPlayerOneScore;
        VersusSnakeControllerPlayerTwo.onDeath += ResetPlayerTwoScore;
    }

    public void OnDisable()
    {
        FoodVersus.onFoodCollectedByPlayerOne -= IncreasePlayerOneScore;
        FoodVersus.onFoodCollectedByPlayerTwo -= IncreasePlayerTwoScore;

        VersusSnakeControllerPlayerOne.onDeath -= ResetPlayerOneScore;
        VersusSnakeControllerPlayerTwo.onDeath -= ResetPlayerTwoScore;
    }

    private void IncreasePlayerOneScore()
    {
        playerOneFoodCount++;
        playerOneCurrentScore.SetCurrentScore(playerOneFoodCount);
        CheckHighScore(playerOneFoodCount);
    }

    private void IncreasePlayerTwoScore()
    {
        playerTwoFoodCount++;
        playerTwoCurrentScore.SetCurrentScore(playerTwoFoodCount);
        CheckHighScore(playerTwoFoodCount);
    }


    private void ResetPlayerOneScore()
    {
        playerOneFoodCount = 0;
        playerOneCurrentScore.ResetCurrentScore();
    }

    private void ResetPlayerTwoScore()
    {
        playerTwoFoodCount = 0;
        playerTwoCurrentScore.ResetCurrentScore();
    }
    
    void CheckHighScore(int scoreToCheck)
    {
        if (scoreToCheck > PlayerPrefs.GetInt("Medium VS High Score", 0))
        {
            PlayerPrefs.SetInt("Medium VS High Score", scoreToCheck);
            UpdateHighScore();
        }
    }
    
    void UpdateHighScore()
    {
        highScoreText.text = "MEDIUM VS HIGH SCORE: " + PlayerPrefs.GetInt("Medium VS High Score", 0).ToString();
    }
}
