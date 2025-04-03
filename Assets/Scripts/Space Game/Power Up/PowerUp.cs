using UnityEngine;

/// <summary>
/// Product 
/// </summary>
public abstract class PowerUp : MonoBehaviour, IPowerUp
{
    public string PowerUpName { get; set; }
    [Header("Power Up Stats")]
    [SerializeField] private float powerUpSpeed = 2f;
    [SerializeField] private float powerUpBound = -11f;

    public abstract void CreatePowerUp();

    public abstract void ApplyPowerUp();

    protected virtual void Update()
    {
        PowerUpMovement(powerUpSpeed);
        DeactivePowerUp(powerUpBound);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUp();
            Debug.Log($"{PowerUpName} is applied to {other.gameObject.name}");
            // unactive game object
        }
    }

    private void PowerUpMovement(float speed)
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void DeactivePowerUp(float bound)
    {
        if(transform.position.y < bound)
        {
            HealthPool.Instance.ReturnHealthToPool(this as HealthPowerUp);
        }
    }
}
