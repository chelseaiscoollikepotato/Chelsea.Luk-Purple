using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = 1;
        Vector3 destination = new Vector3(horizontal, 0, vertical);
        transform.Translate(destination * speed * Time.deltaTime);
    }
}
