using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Level level;

    public Text remainingText;
    public Text remainingSubtext;
    public Text targetText;
    public Text targetSubtext;
    public Text scoreText;

    public Image[] stars;

    private int starIndex;
    private bool isgameOver;

    // Start is called before the first frame update
    private void Start()
    {
        UpdateStars();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == starIndex)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
