using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;


    void Update()
    {
        Transform parent = pauseMenu.transform.parent;

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            int activeChildren = 0;
            for (int i = 0; i<parent.childCount; i++) {
                if (parent.GetChild(i).gameObject.activeSelf) {
                    activeChildren++;
                }
            }


            // can only pause if other menus aren't active
            if (activeChildren < 2)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }

    }

    public void continueGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
    }

    public void exitGame() {
        Application.Quit();
    }

}
