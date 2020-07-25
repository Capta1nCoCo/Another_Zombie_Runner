using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] DisplayDamage displayDamage;
        
    void Update()
    {
        DisplayHealth();
    }

    private void DisplayHealth()
    {
        healthText.text = health.ToString();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("You Died");
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
    
}
