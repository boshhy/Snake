using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCurrentScore : MonoBehaviour
{
    public TextMeshProUGUI currentScore;


    public void SetCurrentScore(int newScore)
    {
        currentScore.text = newScore.ToString();
    }

    public void ResetCurrentScore()
    {
        currentScore.text = "0";
    }
}
