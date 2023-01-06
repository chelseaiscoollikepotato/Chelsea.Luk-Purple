using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialog;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };
        createClue();
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialog();
    }

    private void searchDialog()
    {
        dialog = "Hi! Can you help me find my " + collectibles[clue] + "?";

        switch (clue)
        {
            case 0:
                dialog = "I'm trying to make a movie but I lost my film! Can you help me find it?";
                break;
            case 1:
                dialog = "Oh no! I've lost the balloons to my party, can you help?";
                break;
            case 2:
                dialog = "Help! My friend is drowning! Can you help me find the life saver?";
                break;
            case 3:
                dialog = "I want to play dart but I lost my bull's eye, can you help me find it?";
                break;
            case 4:
                dialog = "Can you help me find my grandpa's pipe?";
                break;
            case 5:
                dialog = "Oh no, I've lost the key to my car! Can you help?";
                break;
            case 6:
                dialog = "Help! I lost my fish! Can you help find him?";
                break;
            case 7:
                dialog = "I was going to feed the birds with my birdhouse but it was gone! Can you help me find it?";
                break;
            case 8:
                dialog = "can you help me find my red airhorn?";
                break;
            case 9:
                dialog = "I have a talent show coming up but I lost my magic hat! Can you help me find it?";
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play(0);
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialog, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialog = "You found my " + collectibles[clue] + "! Hooray!";
            end = true;
        }
        else
        {
            dialog = "No, that's not my " + collectibles[clue] + ".";
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }

}
