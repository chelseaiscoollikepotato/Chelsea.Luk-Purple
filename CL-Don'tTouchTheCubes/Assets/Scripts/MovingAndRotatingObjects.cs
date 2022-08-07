using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAndRotatingObjects : MonoBehaviour
{
    [Header("Default Movement Speed")]
    //Default moving speed
    public float moveSpeed = 10f;
    [Header("Dfault Rotation Speed")]
    //Default rotating speed
    public float rotateSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        //Object moving on the y axis based on move speed
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        //Rotate on the x axis based on rotate speed
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
