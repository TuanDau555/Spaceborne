using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPool : MonoBehaviour
{
    public static HealthPool Instance { get; private set; }

    [SerializeField] private int poolSize;
    [SerializeField] private HealthPowerUp healthToPool;

    private Stack<HealthPowerUp> healthPowerUpStack = new Stack<HealthPowerUp>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetPool();
    }

    // Create Pool
    private void SetPool()
    {
        if (healthToPool == null)
            return;

        // Caculate how many health...
        for(int i = 0; i < poolSize; i++)
        {
            // ... then create health to stack...
            HealthPowerUp health = Instantiate(healthToPool);
            // Make sure them are unactive when created
            health.gameObject.SetActive(false);
            // ... and push them to stack...
            healthPowerUpStack.Push(health);
            // ... set it as child of its parent
            health.transform.SetParent(transform);
        }
    }
    
    // Return the first acitve health from the pool
    public HealthPowerUp GetPooledHealth(Vector3 position)
    {
        // If stack is not large enough (or you forget to create stack), instantiate new health pool
        if(healthPowerUpStack.Count == 0)
        {
            HealthPowerUp newHealthPowerUpStack = Instantiate(healthToPool, position, Quaternion.identity);
            return newHealthPowerUpStack;
        }

        // Grab the next one from the list
        HealthPowerUp nextHealth = healthPowerUpStack.Pop();
        // Reset it postion because dont want to active at it last deactive position
        nextHealth.transform.position = position;
        nextHealth.gameObject.SetActive(true);
        return nextHealth;
    }

    //Deactive them if out of screen or collide with player
    public void ReturnHealthToPool(HealthPowerUp pooledHealth)
    {
        healthPowerUpStack.Push(pooledHealth);
        pooledHealth.gameObject.SetActive(false );
    }
}
