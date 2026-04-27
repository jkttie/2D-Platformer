using System;
using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    private float health;
    private bool canReciveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float newHealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthInitializer(float newHealth);
    public event HealthInitializer OnHealthInitialized;

    void Start()
    {
        health = MaxHealth;
        OnHealthInitialized?.Invoke(health);
    }

    public void AddDamage(float damage)
    {
        if (canReciveDamage)
        {
            health -= damage;
            OnHealthChanged?.Invoke(health, -damage);
            canReciveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }
        Debug.Log(health);
    }
    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        canReciveDamage = true;
        Debug.Log("reset");
    }
    public void AddHealth(float heal)
    {
        health += heal;
        OnHealthChanged?.Invoke(health, heal);
        Debug.Log(health);
    }
}
