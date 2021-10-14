using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tablet : MonoBehaviour
{
    // Start is called before the first frame update

    public InputField input;
    public GameObject tabletCanvas;
    public GameObject menuCamera;
    private const string password = "books";
    public bool puzzleDone = false;
    public GameObject key;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            exitMenu();
        }
    }

    void exitMenu()
    {
        Time.timeScale = 1;
        tabletCanvas.SetActive(false);
        menuCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void VerifyCode()
    {
        if (input.text.ToLower() == password)
        {

            // show guess is correct
            // wait 2 seconds
            exitMenu();
            puzzleDone = true;
            key.SetActive(true);
            return;
        }

        // show guess is incorrect
        gameObject.GetComponent<AudioSource>().Play();

    }
}
