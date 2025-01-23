using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformations : MonoBehaviour
{
    [SerializeField] private int maxPlayerHealthpoints;
    [SerializeField] private int currentPlayerHealthpoints;
    [SerializeField] private Image healthbar;
    [SerializeField] private ColorSpriteSetter _colorSpriteSetter;
    private void Awake()
    {
        currentPlayerHealthpoints = maxPlayerHealthpoints;
        RefreshHealthbar();
    }

    public void GetDamage(int dmg)
    {
        if (currentPlayerHealthpoints < 1) return;
        
        currentPlayerHealthpoints -= dmg;
        
        _colorSpriteSetter.ColorObject();
        if (currentPlayerHealthpoints < 1)
        {
            GetComponent<PlayerController>().OnDeath();
        }
        
        RefreshHealthbar();
    }

    public void GetHealthpoints(int healthpoints)
    {
        currentPlayerHealthpoints += healthpoints;

        if (currentPlayerHealthpoints > maxPlayerHealthpoints)
        {
            currentPlayerHealthpoints = maxPlayerHealthpoints;
        }
        
        RefreshHealthbar();
    }

    void RefreshHealthbar()
    {
        healthbar.fillAmount = (float)currentPlayerHealthpoints / (float)maxPlayerHealthpoints;
    }
    
    
    
}
