using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SelectColorChange : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private TextMeshProUGUI theTextHolder;

    private void Start()
    {
        theTextHolder = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        theTextHolder.alpha = 0.2f;
    }

    public void OnSelect(BaseEventData eventData)
    {
        theTextHolder = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        theTextHolder.alpha = 1.0f;
    }

    
    public void OnDeselect(BaseEventData eventData)
    {
        theTextHolder = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        theTextHolder.alpha = 0.2f;
    }
}
