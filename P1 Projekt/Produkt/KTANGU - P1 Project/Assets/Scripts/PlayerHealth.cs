using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth
{
    // Data fields for health
    int currentHealth;
    int currentMaxHealth;

    // Properties that changes the health fields 
    public int Health
    {
        get 
        { 
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }
    public int MaxHealth
    {
        get 
        { 
            return currentMaxHealth;
        }
        set
        {
            currentMaxHealth = value;
        }
    }
    // Constructor
    public PlayerHealth(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    // Methods
    public void DmgPlayer(int dmgAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= dmgAmount;
        }
    }
}
