using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Slider healthSlider;
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthbar();
    }

    public void SubHealth(int amount)
    {
        if (!GetComponent<FightingController>().blocked) { 
        if(health <= amount)
        {
            Destroy(gameObject);
        }
        health -= amount;
        }
    }
    public void AddHealth(int amount)
    {
        if(health+amount >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += amount;
        }
    }
    public void UpdateHealthbar()
    {
        healthSlider.value = health;
    }
}
