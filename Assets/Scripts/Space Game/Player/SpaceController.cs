using System.Collections;
using UnityEngine;

public class SpaceController : MonoBehaviour
{
    [SerializeField] private ConcreteFactoryHealth ConcreteFactoryHealth;

    private float spaceSpeed = 5f;
    private float fireRate = 0.2f;
    private Vector2 shipMovement;

    private Rigidbody2D spaceRb;
    //private Animator shipAnim;
    private Coroutine shootingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        spaceRb = GetComponent<Rigidbody2D>();
        //shipAnim = GetComponent<Animator>();

        StartShooting();
    }
    /// <summary>
    /// This line is testing git 
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        SpaceInput();
        //ShipAnim();
    }

    private void FixedUpdate()
    {
        spaceRb.MovePosition(spaceRb.position + shipMovement * spaceSpeed * Time.fixedDeltaTime);
    }

    void SpaceInput()
    {
        if(!GameManager.Instance.isGameActive)
        {
            spaceSpeed = 0;
        }
        float moveY = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
        shipMovement = new Vector2(moveX, moveY).normalized;
    
        /*if (Input.GetKeyDown(KeyCode.H))  
            ConcreteFactoryHealth.GetPowerUp(new Vector3(0, 0, 0));*/
    }

    protected void StartShooting()
    {
        if (shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(ShootingAutomatic());
        }

    }

    private IEnumerator ShootingAutomatic()
    {
        while (GameManager.Instance.isGameActive)
        {
            GameObject bullets = ObjectPooler.Instance.GetPooledObject();
            if (bullets != null)
            {
                bullets.transform.position = transform.position;
                bullets.SetActive(true);
            }

            yield return new WaitForSeconds(fireRate);
        }

    }

    

    /*
    void ShipAnim()
    {
        shipAnim.SetFloat("Horizontal", shipMovement.x);
        shipAnim.SetFloat("ship_Speed", shipMovement.sqrMagnitude);
    }*/
}