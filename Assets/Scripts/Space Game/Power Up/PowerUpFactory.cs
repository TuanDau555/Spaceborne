using UnityEngine;

/// <summary>
/// IProduct
/// </summary>
public interface IPowerUp
{
    public string PowerUpName {  get; set; }
    public void CreatePowerUp();
    public void ApplyPowerUp();
}

/// <summary>
/// Factory
/// </summary>
public abstract class PowerUpFactory : MonoBehaviour
{
    public abstract IPowerUp GetPowerUp(Vector3 position);
    //logic that is shared with all factories...
    
}
