using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//User Interface namespace
using UnityEngine.UI;
//Scene Management namespace
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Current cube game object
    [Header("Cube Object")]
    public GameObject currentCube;
    //Last cube game object
    [Header("Last Cube Object")]
    public GameObject lastCube;
    //Text object
    [Header("Text Object")]
    public Text text;
    //Level number interger
    [Header("Current Level")]
    public int Level;
    //Boolean determining if game
    //is over
    [Header("Boolean")]
    public bool Done;
    // Start is called before the first frame update
    void Start()
    {
        //Call New Block function
        Newblock();
    }

    // Update is called once per frame
    void Update()
    {
        //If done is true
        if (Done)
        {
            //return value
            return;
        }
        //Variable time equals to the time scine game startup
        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);
        //Variable pos1 equals last cube position
        var pos1 = lastCube.transform.position + Vector3.up * 10f;
        //variable pos2 equals to the last pos1 plus any level by number of 2
        var pos2 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;
        var pos3 = pos1 - ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;
        //If the level is by the number of two
        if (Level % 2 == 0)
        {
            //Current position of the current cube based of the 3 axis of
            //pos2, pos1 and time
            currentCube.transform.position = Vector3.Lerp(pos2, pos3, time);
        }
        else
        {
            //Current positiob of the current cube based of tge 3 axis of
            //pos1, pos2 and time
            currentCube.transform.position = Vector3.Lerp(pos3, pos2, time);
        }
        //If left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //New block function
            //is called
            text.text = "Final Score: " + Level;
            Newblock();
        }
    }

    //New Block function to create new blocks
    //for the game
    void Newblock()
    {
        //If the last cube is not
        //destroyed
        if(lastCube != null)
        {
            //The current cube position equals to all 3 axis positions
            //to the nearest interger
            currentCube.transform.position = new Vector3(Mathf.Round(currentCube.transform.position.x),
                currentCube.transform.position.y,
                Mathf.Round(currentCube.transform.position.z));
            //current cubes size equals to the last cube size
            currentCube.transform.localScale = new Vector3(lastCube.transform.localScale.x - Mathf.Abs(currentCube.transform.position.x - lastCube.transform.position.x),
                                                            lastCube.transform.localScale.y,
                                                           lastCube.transform.localScale.z - Mathf.Abs(currentCube.transform.position.z - lastCube.transform.position.z));
            //current cubes positions equals to the current cubes x position
            //last cubes y position
            //z axis position of 0.5
            currentCube.transform.position = Vector3.Lerp(currentCube.transform.position, lastCube.transform.position, 0.5f) + Vector3.up * 5f;

            //is less than or equal to 0 or if the
            //current cube size is on the z axis is less
            // than or equal to 0
            if (currentCube.transform.localScale.x <= 0f ||
                currentCube.transform.localScale.z <= 0f)
            {
                //Done equals true
                Done = true;
                //Text is visible
                text.gameObject.SetActive(true);
                //Text equals to the text of the Final score
                //and which level is played
                text.text = "Final Score: " + Level;
                //Start Corountine function x
                StartCoroutine(X());
                //Returns value
                return;
            }
        }

        //Last cube equals to the
        //current cube
        lastCube = currentCube;
        //Current cube equals to the spawned
        //last cube
        currentCube = Instantiate(lastCube);
        //Current cubes name equals to the
        //level number
        currentCube.name = Level + "";
        //Current cube component mesh renderer material
        //set the color according to the color settings
        currentCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f));
        //Add 1 to level
        Level++;
        //Camera position equals to the
        //position of the current cube
        Camera.main.transform.position = currentCube.transform.position + new Vector3(100, 100, 100);
        //Camera looks at the current cube
        Camera.main.transform.LookAt(currentCube.transform.position);
    }

    //IEnumertor X function
    IEnumerator X()
    {
        //Wait three seconds then code is
        //executed
        yield return new WaitForSeconds(3f);
        //The scene sample scene is loaded
        SceneManager.LoadScene("SampleScene");
    }
}
