using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float yForce;
    public float xForce;
    public float xDirection;

    private Rigidbody2D playerRigidbody;
    // Start is called before the first frame update
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Vector2 Pushforce = new Vector2(xForce, 0f);
            playerRigidbody.AddForce(Pushforce);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
