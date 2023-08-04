using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
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
        Food.onFoodCollected += IncreaseScore;
        SnakeController.onDeath += ResetScore;
    }

    public void OnDisable()
    {
        Food.onFoodCollected -= IncreaseScore;
        SnakeController.onDeath -= ResetScore;
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
        if (foodCount > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", foodCount);
            UpdateHighScore();
        }
    }
    
    void UpdateHighScore()
    {
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("High Score", 0).ToString();
    }
}
