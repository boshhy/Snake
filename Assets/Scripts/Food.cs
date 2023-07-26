using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int xBounds = 41;
    public int yBounds = 22;
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
        float x = Random.Range(-xBounds, xBounds);
        float y = Random.Range(-yBounds, yBounds);
        gameObject.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }
}
