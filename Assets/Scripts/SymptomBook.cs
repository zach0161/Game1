using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymptomBook : MonoBehaviour
{

    int pageIndex = 0;
    public List<GameObject> pages;
    public GameObject canvas;
    public GameObject menuCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            exitMenu();
        }
    }

    public void buttonPressed(string direction)
    {

        pages[pageIndex].SetActive(false);

        if (direction == "forward")
        {
            pageIndex += 1;
        }
        else
        {
            pageIndex -= 1;
        }

        pages[pageIndex].SetActive(true);

    }

    void exitMenu()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        menuCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
