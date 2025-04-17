using UnityEngine;

/// <summary>
/// IProduct
/// </summary>
public interface IEnemy
{
    public string EnemyName { get; set; }
    public void CreateEnemy();
    public void EnemyAttack();
}

/// <summary>
/// Factory for creating enemies
/// </summary>
public abstract class EnemyFactory : MonoBehaviour
{
    // Factory Method
    // This method will be overridden by the concrete factories
    public abstract IEnemy GetEnemy(Vector3 position);
}
