﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //Rotate the object ox the x axis
        transform.Rotate(Vector3.forward, Time.deltaTime * 10f);
    }
}
