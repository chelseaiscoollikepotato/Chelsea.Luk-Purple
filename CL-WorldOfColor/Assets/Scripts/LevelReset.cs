using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public ParticleSystem explosion;
    public ParticleSystem trail;

    public GameObject player;
    public GameObject GameOverScreen;
    void Start()
    {
        explosion.Stop();
        trail.Play();
        GameOverScreen.SetActive(false);
    }

    void fixedUpdate()
    {
        explosion.transform.position = player.transform.position;
    }
    public void GameOver()
    {
        player.SetActive(false);
        Invoke("Reload", 2);
        explosion.Play();
        trail.Stop();
        GameOverScreen.SetActive(true);
    }

    void Reload()
    {
        SceneManager.LoadScene(0);
    }
}


