using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbod;

    float jumpForce = 5.7f;

    public bool isGrounded;
    

    float fallMultiplier = 1.5f;

    void Start()
    {
        rigidbod = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 15f);
        Debug.DrawRay(transform.position, Vector3.down * .15f, Color.red);

        if(Input.GetButtonDown("Jump") && isGrounded){
            rigidbod.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(rigidbod.velocity.y < 0)
        {
            rigidbod.velocity += Physics.gravity * fallMultiplier * Time.deltaTime;
        }
    }
}

