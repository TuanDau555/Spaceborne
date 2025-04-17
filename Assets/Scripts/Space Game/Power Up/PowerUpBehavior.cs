using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// How it Power Up will work
/// </summary>
public class PowerUpBehavior : MonoBehaviour
{
    // List of factories
    public float spawnRate;
    public List<PowerUpFactory> PowerUpFactories;
    private PowerUpFactory _powerUpFactory;

    private void Start()
    {
        //Start to Spawn Random Power Up
        StartCoroutine(nameof(SpawnRandomPowerUp));
    }

    private IEnumerator SpawnRandomPowerUp()
    {
        while (GameManager.Instance.isGameActive)
        {
            if (PowerUpFactories == null || PowerUpFactories.Count == 0)
            {
                Debug.LogError("PowerUpFactories list is empty or null!");
            }

            yield return new WaitForSeconds(spawnRate);
            // Random Factory
            _powerUpFactory = PowerUpFactories[Random.Range(0, PowerUpFactories.Count)];

            // Spawn Power Up at random position
            Vector3 spawnPosition = new Vector3(Random.Range(-7f, 7f), 13f, 0f);
            IPowerUp powerUp = _powerUpFactory.GetPowerUp(spawnPosition);
            powerUp.CreatePowerUp();
        }
    }

}