using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
