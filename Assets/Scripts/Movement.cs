using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float runSpeed = 20;
    float horizontalMovement = 0f;
    float verticalMovement = 0f;
    public float horizontalCamSpeed = 1f;
    public float verticalCamSpeed = 1f;
    private float xRotation;
    private float yRotation;

    public Transform playerCamera;
    public CharacterController controller;

    void Start()
    {
        //locks cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        // checks for different kinds of input by player
        horizontalMovement = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * runSpeed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X") * horizontalCamSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * verticalCamSpeed;

        // add the inputs to the rotation. Y-axis is flipped
        yRotation += mouseX;
        xRotation -= mouseY;

        // player can only look 90 degrees up/down
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //rotates player according to mouse movements
        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        playerCamera.eulerAngles = new Vector3(xRotation, yRotation, 0f);

        // moves the player
        Vector3 movement = (transform.right * horizontalMovement + transform.forward * verticalMovement);
        movement.y = 0;
        controller.Move(movement);

    }
}
