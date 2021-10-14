using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCode : MonoBehaviour
{
    List<int> enteredCode = new List<int>();
    List<int> code;
    public GameObject canvas;
    public GameObject menuCamera;
    public Animator door;
    public Player player;
    public Xylophone xylophone;

    // Start is called before the first frame update
    void Start()
    {
        switch (player.pickedDisease)
        {
            // ABC = 1, DEF = 2, GHI = 3, JKL = 4, MNO = 5, PQRS = 6, TUV = 7, WXYZ = 8
            case "ptsd":
                code = new List<int> { 6, 7, 6, 4 };
                break;
            case "adhd":
                code = new List<int> { 1, 2, 3, 2 };
                break;
            case "depression":
                code = new List<int> { 2, 2, 6, 6, 2, 6, 6, 3, 5, 5 };
                break;
            case "anxiety":
                code = new List<int> { 1, 5, 8, 3, 2, 7, 8 };
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            exitMenu();
        }
    }

    public void buttonPressed(int key)
    {
        enteredCode.Add(key);
        // can only open door if all other puzzles are completed
        if (enteredCode.Count == code.Count && xylophone.puzzleCompleted)
        {

            if (checkCorrectKeys(enteredCode, code))
            {
                door.SetBool("Open", true);
                exitMenu();
            }
            else
            {
                enteredCode.RemoveRange(0, enteredCode.Count);
                //tell player that it is incorrect
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    void exitMenu()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        menuCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        enteredCode.RemoveRange(0, enteredCode.Count);
    }

    bool checkCorrectKeys(List<int> enteredCode, List<int> rightCode)
    {
        for (int i = 0; i < enteredCode.Count; i++)
        {
            if (enteredCode[i] != rightCode[i]) return false;
        }
        return true;

    }
}
