using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSelectPlay : MonoBehaviour
{
    public Button primaryButton;

    void OnEnable()
    {
           primaryButton.Select();
    }
}