using UnityEngine;

public class KamikazeEnemyConcrete : EnemyFactory
{
    [SerializeField] private KamikazeEnemy kamikazeEnemyPrefab;
    [SerializeField] private float kamikazeEnemySpeed;

    public override IEnemy GetEnemy(Vector3 position)
    {
        // Create a new Kamikaze enemy instance
        KamikazeEnemy newKamikazeEnemy = Instantiate(kamikazeEnemyPrefab, position, Quaternion.identity);
        newKamikazeEnemy.CreateEnemy();
        return newKamikazeEnemy;
    }
}
