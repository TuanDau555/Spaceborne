using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float flightSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * flightSpeed * Time.deltaTime);
    }

}
