using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FoodVersus : MonoBehaviour
{
    public static event Action onFoodCollectedByPlayerOne;
    public static event Action onFoodCollectedByPlayerTwo;

    public VersusSnakeControllerPlayerOne playerOne;
    public VersusSnakeControllerPlayerTwo playerTwo;

    public int xBoundsLow = -41;
    public int yBoundsLow = -22;

    public int xBoundsHigh = 41;
    public int yBoundsHigh = 17;
    
 
    // Start is called before the first frame update
    void Start()
    {
        setRandom();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setRandom()
    {

        float x = UnityEngine.Random.Range(xBoundsLow, xBoundsHigh);
        float y = UnityEngine.Random.Range(yBoundsLow, yBoundsHigh);
        
        gameObject.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
        
        if (playerOne.DoesItOverlap(gameObject.transform.position) || playerTwo.DoesItOverlap(gameObject.transform.position))
        {
            setRandom();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerOne")
        {
            AudioManager.instance.PlaySFX(0);
            if (onFoodCollectedByPlayerOne != null)
            {
                onFoodCollectedByPlayerOne();
            }
            setRandom();
        }

        if (other.tag == "PlayerTwo")
        {
            AudioManager.instance.PlaySFX(0);
            if (onFoodCollectedByPlayerTwo != null)
            {
                onFoodCollectedByPlayerTwo();
            }
            setRandom();
        }
    }
}
