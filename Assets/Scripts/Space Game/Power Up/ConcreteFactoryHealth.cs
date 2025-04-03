using UnityEngine;

/// <summary>
/// Concrete Factroy Product
/// </summary>
public class ConcreteFactoryHealth : PowerUpFactory
{
    [SerializeField] private HealthPowerUp healthPrefab;
    [SerializeField] private float healthSpeed;

    public override IPowerUp GetPowerUp(Vector3 position)
    {
        // Health pool go here
        HealthPowerUp newHealth = HealthPool.Instance.GetPooledHealth(position);
        newHealth.CreatePowerUp();
        return newHealth;
    }
}
