using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Camera playerCamera;

    float mouseX;
    float mouseY;
    float mouseSensitivity = 1000f;
    float horizAxis;
    float vertAxis;

    float xRotation = 0f; //horizontal
    float yRotation = 0f; //vertical
    float moveSpeed = 10f;
    Vector3 velocity;  //can serialise for testing
    float gravity = -9.81f;
    float jumpHeight = 0.8f;  //can serialise during testing
    float groundDistance = 0.3f;
    bool isGround;
    bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        CheckIfGrounded();
        CheckisJump();
        ApplyMouseDirection();
        ApplyMovement();
    }

    void GetInputs()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        horizAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");
        isJump = Input.GetButtonDown("Jump");
    }

    void CheckIfGrounded()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        else if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    void CheckisJump()
    {
        if (isJump && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void ApplyMouseDirection()
    {
        yRotation -= mouseY * mouseSensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -10f, 10f);     //limit looking up and down
        playerCamera.transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        //comment above 3 lines to restrict looking up and down

        xRotation = mouseX * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * xRotation);
    }

    void ApplyMovement()
    {
        Vector3 move = (transform.right * horizAxis) + (transform.forward * vertAxis);
        controller.Move(move * moveSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }


    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}
