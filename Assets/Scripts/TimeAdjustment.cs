using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAdjustment : MonoBehaviour
{
    public float myFixedDeltaTime = 0.2f;

    void Awake()
    {
        Time.fixedDeltaTime = myFixedDeltaTime;
    }

}
