using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiseasePicker : MonoBehaviour
{

    public Player player;
    public GameObject canvas;
    public GameObject menuCamera;
    string diseaseGuess;
    public Dropdown dropdown;
    public Radio radio;

    // Start is called before the first frame update

    void Update() {
        diseaseGuess = dropdown.options[dropdown.value].text;
    }

    public void confirmButton()
    {
        if (diseaseGuess.ToLower() == player.pickedDisease)
        {
            Time.timeScale = 1f;
            radio.playAlmostDone();
            canvas.SetActive(false);
            menuCamera.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //lose condition
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);

        }

    }
}
