using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 5f;
    private float bottomBound = -6f;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > topBound && CompareTag("Bullets"))
        {
            gameObject.SetActive(false);
        }

        if(transform.position.y < bottomBound)
        {
            Destroy(gameObject); ;
        }

        if(transform.position.y < bottomBound && CompareTag("Health"))
        {
            gameObject.SetActive(false);
        }
    }
}
