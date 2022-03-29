using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class UIControls : MonoBehaviour
{
    public Slider healthBar;
    public TMP_Text healthBarValueLabel;

    private void Start()
    {
        
    }

    public void OnStartButton_Pressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnHealthBar_Changed()
    {
        healthBarValueLabel.text = healthBar.value.ToString();
    }

    
    
}
