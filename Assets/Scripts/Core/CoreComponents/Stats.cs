using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    public event Action onHealthZero;
    public float StunResistance { get => stunResistance; set => stunResistance = value; }
    public float StunRecoveryTime { get => stunRecoveryTime; set => stunRecoveryTime = value; }

    [SerializeField] private float stunRecoveryTime = 0.5f;
    [SerializeField] private float stunResistance = 30;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    protected override void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            onHealthZero?.Invoke();
            Debug.Log("health is zero");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
