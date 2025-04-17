using Unity.VisualScripting;
using UnityEngine;

public class KamikazeEnemy : Enemy
{
    [Header("Kamikaze Enemy Stats")]
    [SerializeField] private int kamikazeDamage;

    public override void CreateEnemy()
    {
        EnemyName = "Kamikaze Enemy";
        // Additional initialization for KamikazeEnemy
    }

    public override void EnemyAttack()
    {
        // Logic for KamikazeEnemy attack
        Debug.Log($"{EnemyName} kamikaze attack!");
        // For example, deal damage to the player or destroy the enemy
    }
}
