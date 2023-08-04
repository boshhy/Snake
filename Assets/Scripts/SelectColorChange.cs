using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SelectColorChange : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Button primaryButton;
    private TextMeshProUGUI theTextHolder;

    private void Start()
    {
        theTextHolder = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        theTextHolder.alpha = 0.2f;
        if(primaryButton){
            primaryButton.GetComponentInChildren<TextMeshProUGUI>().alpha = 1.0f;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("In SetColor Script");
        theTextHolder = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        theTextHolder.alpha = 1.0f;
        //AudioManager.instance.PlaySFX(0);
    }

    
    public void OnDeselect(BaseEventData eventData)
    {
        theTextHolder = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        theTextHolder.alpha = 0.2f;
    }

    public void SelectIt()
    {
        theTextHolder = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        theTextHolder.alpha = 1.0f;
    }

}
