using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float yForce;
    private Rigidbody2D enemyRigidbody;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (transform.position.x <= -8)
        {
            
        }
        if (transform.position.x >= 8)
        {
            
        }
        float newXPosition = transform.position.x * Time.deltaTime;
        float newYPosition = transform.position.y;
        Vector2 newPosition = new Vector2(newXPosition, newYPosition);
        transform.position = newPosition;
    }
}