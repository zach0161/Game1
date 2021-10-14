using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToDiseaseMenu : MonoBehaviour
{

    public Xylophone xylophone;
    public GameObject diseaseMenu;
    public GameObject menuCamera;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (xylophone.puzzleCompleted && Vector3.Distance(gameObject.transform.position, player.position) < 15)
        {
            if (Input.GetKeyDown("e")) {
                Cursor.lockState = CursorLockMode.None;
                menuCamera.SetActive(true);
                diseaseMenu.SetActive(true);
            }
        }   
    }
}
