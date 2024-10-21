using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float actualHealth;
    public float maxHealth;
    
    void Update()
    {
        healthBar.fillAmount = actualHealth / maxHealth;
    }

    void GetDamage(float damage)
    {
        actualHealth -= damage;
    }
}
