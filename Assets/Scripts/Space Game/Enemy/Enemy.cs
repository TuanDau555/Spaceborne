using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public string EnemyName { get; set; }

    public virtual void CreateEnemy()
    {
        // Logic to create the enemy
        Debug.Log($"{EnemyName} created!");
    }

    public virtual void EnemyAttack()
    {
        // Logic for enemy attack
        Debug.Log($"{EnemyName} attacks!");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Logic for when the enemy collides with the player
            // For example, deal damage to the player or destroy the enemy
            EnemyAttack();
            Debug.Log($"{EnemyName} collided with {other.gameObject.name}!");
        }
    } 

    private void DeactiveEnemy()
    {
        // Logic to deactivate the enemy
        
    }
}