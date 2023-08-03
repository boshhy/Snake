using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTwoPlayersHard : MonoBehaviour
{
    public TextCurrentScore CurrentScore;
    public TextMeshProUGUI highScoreText;
    public int foodCount = 0;
    
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
        FoodPlayerOne.onFoodCollected += IncreaseScore;
        FoodPlayerTwo.onFoodCollected += IncreaseScore;
        SnakeControllerPlayerOne.onDeath += ResetScore;
        SnakeControllerPlayerTwo.onDeath += ResetScore;
    }

    public void OnDisable()
    {
        FoodPlayerOne.onFoodCollected -= IncreaseScore;
        FoodPlayerTwo.onFoodCollected -= IncreaseScore;
        SnakeControllerPlayerOne.onDeath -= ResetScore;
        SnakeControllerPlayerTwo.onDeath -= ResetScore;
    }

    private void IncreaseScore()
    {
        foodCount++;
        CurrentScore.SetCurrentScore(foodCount);
        CheckHighScore();
    }

    private void ResetScore()
    {
        foodCount = 0;
        CurrentScore.ResetCurrentScore();
    }

    void CheckHighScore()
    {
        if (foodCount > PlayerPrefs.GetInt("Medium Co-op High Score", 0))
        {
            PlayerPrefs.SetInt("Medium Co-op High Score", foodCount);
            UpdateHighScore();
        }
    }
    
    void UpdateHighScore()
    {
        highScoreText.text = "MEDIUM CO-OP HIGH SCORE: " + PlayerPrefs.GetInt("Medium Co-op High Score", 0).ToString();
    }
}