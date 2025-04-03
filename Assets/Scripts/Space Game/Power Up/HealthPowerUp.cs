using UnityEngine;

/// <summary>
/// One of the children of the Product
/// </summary>
public class HealthPowerUp : PowerUp
{

    [Header("Health Stats")]
    [SerializeField] private int healingPoint;

    public override void CreatePowerUp()
    {
        PowerUpName = "Health Power Up";
    }

    // When collide with player
    public override void ApplyPowerUp()
    {
        if (GameManager.Instance != null)
        {
            //... increase health
            GameManager.Instance.HealthCount(healingPoint);
        }
        // ... unactive health prefabs to pool
        HealthPool.Instance.ReturnHealthToPool(this);
    }
}
