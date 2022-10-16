using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator Animator;

    Jump Jump;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
