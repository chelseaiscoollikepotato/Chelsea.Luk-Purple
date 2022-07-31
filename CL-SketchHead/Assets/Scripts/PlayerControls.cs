using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    //Rigidbody2D object that is stored
    [Header("Rigidbody")]
    public Rigidbody2D rb;
    [Header("Default Down Speed")]
    //Downward speed of the object
    public float downSpeed = 20f;
    [Header("Default movement Speed")]
    //Movement speed of the object
    public float movementSpeed = 10f;
    [Header("Default Directional Movement Speed")]
    //Movement direction of the object
    public float movement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Variable equals to component Rigidbody2D
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //Movement equals Horizontal movement
        //Multiplied by the movement speed
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //If direction on x axis is less than 0
        if (movement < 0)
        {
            //Object faces to the left
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        //If direction ox x axis is greater than 0
        else
        {
            //Object faces to the right
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    //FixedUpdate called every fixed rate frame
    void FixedUpdate()
    {
        //Vector2 which is (x,y) velocity
        //equals to the velocity of the Rigidbody2D
        Vector2 velocity = rb.velocity;
        //Velocity of the x axis equals to
        //The direction movement on the x axis
        //Of the character
        velocity.x = movement;
        //Rigidbody2D velocity equals to
        //velocity of the object
        rb.velocity = velocity; 
    }

    //Collision function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Velocity with the DownSpeed
        rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
    }
}
