using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private float startPosY; 
    private float heightOfBackGround; 

    [SerializeField] private float scrollSpeed; 
    [SerializeField] private float parallaxEffect; 

    void Awake()
    {
        startPosY = transform.position.y; // startPos is (0,0,0)
        heightOfBackGround = GetComponent<SpriteRenderer>().bounds.size.y; // Get heigth of background
    }

    private void FixedUpdate()
    {
        ScrollBackgroundVertically();
    }

    void ScrollBackgroundVertically()
    {
        // caculate and scrolling background
        float moveDistance = scrollSpeed * parallaxEffect * Time.fixedDeltaTime;
        transform.position += Vector3.down * moveDistance;

        // if background scroll over it heigth...
        float currentY = transform.position.y;
        if (currentY <= startPosY - heightOfBackGround)
        {
            //...adjust background to the top 
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y + (2 * heightOfBackGround),
                                             transform.position.z);
        }
    }
}