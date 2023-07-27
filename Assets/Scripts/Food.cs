using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Food : MonoBehaviour
{
    public static event Action onFoodCollected;

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
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlaySFX(0);
            if (onFoodCollected != null)
            {
                onFoodCollected();
            }
            setRandom();
        }
    }
}
