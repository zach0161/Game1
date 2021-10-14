using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Jigsaw : MonoBehaviour
{
    public GraphicRaycaster Raycaster;
    PointerEventData pointerEventData;
    EventSystem eventSystem;
    GameObject selectedPiece;
    GameObject[] pieces;
    int numCorrectPieces = 0;
    public bool puzzleFinished = false;
    public GameObject jigsawCanvas;
    public GameObject menuCamera;

    void Start()
    {
        //Fetch the Event System from the Scene
        eventSystem = GetComponent<EventSystem>();
        pieces = GameObject.FindGameObjectsWithTag("Piece");
    }

    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            exitMenu();
        }

        //Check if the left Mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //Set up the new Pointer Event
            pointerEventData = new PointerEventData(eventSystem);
            //Set the Pointer Event Position to that of the mouse position
            pointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            // Sending out a raycast
            Raycaster.Raycast(pointerEventData, results);

            // Checking if piece is not in already in correct place and no other piece is selected
            if (results[1].gameObject.CompareTag("Piece") && selectedPiece == null)
            {
                selectedPiece = results[1].gameObject;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedPiece = null;
        }

        if (selectedPiece != null)
        {
            selectedPiece.transform.position = Input.mousePosition;
        }

        numCorrectPieces = 0;
        foreach (GameObject piece in pieces)
        {
            if (piece.CompareTag("Piece")) return;
            numCorrectPieces += 1;
        }

        if (numCorrectPieces == 28)
        {
            puzzleFinished = true;
            exitMenu();
        }


    }

    void exitMenu()
    {
        Time.timeScale = 1;
        jigsawCanvas.SetActive(false);
        menuCamera.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}