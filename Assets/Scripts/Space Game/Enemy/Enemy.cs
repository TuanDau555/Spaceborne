using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemySpeed;
    private float XspawnPos = 5.5f;
    private float YspawnPos = 6f;
    public int healthDamage;
    public int pointValue;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = SpawnPosition();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoveDown();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        DetectCollision(other);
    }
    void EnemyMoveDown() // this method is rewriting twice
    {
        transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);

    }

    protected void DetectCollision(Collider2D other) // this method is rewriting twice
    {
        if (other.gameObject.CompareTag("Bullets"))
        {
            other.gameObject.SetActive(false);
            ScoreUpdate();

        }
        if (other.CompareTag("Player"))
        {
            Debug.Log(gameManager);
            Debug.Log("Detected " + other.name);
            if (gameManager != null)
            {
                gameManager.HealthCount(healthDamage);
            }
        }
        Destroy(gameObject);

    }

    protected void ScoreUpdate()
    {
        gameManager.ScoreCount(pointValue);
    }

    protected Vector2 SpawnPosition()
    {
        Vector2 spawnPos = new Vector3(Random.Range(-XspawnPos, XspawnPos), YspawnPos);
        return spawnPos;
    }
}
