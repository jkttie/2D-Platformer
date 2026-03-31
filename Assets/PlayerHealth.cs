using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;
    private bool canReceiveDamage = false;
    public float invincibilityTimer= 2;

    public delegate void HealthChangedHandler(float newHealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    void Start()
    {
        health = maxHealth;
    }

 

    public void AddDamage(float damage)
    {
        if (canReceiveDamage) 
        {
            health -= damage;
          OnHealthChanged?.Invoke(health, damage);   
            canReceiveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvicibility));
        }
        Debug.Log(health);
    }
   
    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvicibility()
    {
        canReceiveDamage = true;
    }
    public void AddHealth(float healToAdd)
    {
        health += healToAdd;
        OnHealthChanged?.Invoke(health, healToAdd);
        Debug.Log(health);

    }
}
