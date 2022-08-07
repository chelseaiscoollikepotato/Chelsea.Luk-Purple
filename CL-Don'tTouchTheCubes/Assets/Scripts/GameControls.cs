using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls: MonoBehaviour
{
    //Timer text object
    private Text timerText;
    //Timer counter for adding score
    private int timerCount;

    // Start is called before the first frame update
    void Start()
    {
        //Game is at a playing state
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
