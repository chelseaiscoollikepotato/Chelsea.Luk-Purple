using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{

    void Update()
    {
        bool hit = Physics.Raycast(transform.position, transform.forward, 2f, 1 << 8);
        Debug.DrawRay(transform.position, transform.forward * 2f, Color.blue);
       if (hit == true){
            Debug.LogWarning("Be Careful!");
        }
        else
        {
            Debug.LogWarning("All Clear!");
        }
    }
}
