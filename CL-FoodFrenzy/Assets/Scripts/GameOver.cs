using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject screenParent;
    public GameObject scoreParent;
    public Text loseText;
    public Text scoretext;
    public Image[] stars;
    private Animator animator;
    // Start is called before the first frame update
    private void Start()
    {
        screenParent.SetActive(false);
        
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = false;
        }

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLose()
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(false);
        loseText.enabled = true;
        
        if (animator)
        {
            animator.Play("GameOverDisplay");
        }
    }
}
