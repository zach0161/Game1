using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{

    public Transform player;
    public Transform target;
    public GameObject canvas;
    public GameObject menuCamera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(target.position, player.position) <= 10)
        {
            //highlight tablet
            if (Input.GetKeyDown("e") && canvas.activeSelf == false)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                canvas.SetActive(true);
                menuCamera.SetActive(true);
            }

        }

    }
}
