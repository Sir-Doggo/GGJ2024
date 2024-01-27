using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Camera playerCamera;
    Animator anim;

    float mouseX;
    float mouseY;
    float mouseSensitivity = 1000f;
    float horizAxis;
    float vertAxis;

    float xRotation = 0f; //horizontal
    float yRotation = 0f; //vertical
    float moveSpeed = 5f;
    Vector3 velocity;  //can serialise for testing
    float gravity = -9.81f;
    [SerializeField] float jumpHeight = 0.8f;  //can serialise during testing
    [SerializeField]
    float groundDistance = 0.05f;
    bool isGround;
    bool isJump;

    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        CheckIfGrounded();
        CheckisJump();
        ApplyMouseDirection();
        ApplyMovement();
        AnimateModel();
        print("Velocity "+ controller.velocity);
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
        anim.SetBool("isGrounded", isGround);
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
        anim.SetBool("isJumping", isJump);
        if (isJump && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }
    }

    void ApplyMouseDirection()
    {
        yRotation -= mouseY * mouseSensitivity * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -20f, 20f);     //limit looking up and down
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

    void AnimateModel()
    {
        if (horizAxis != 0 || vertAxis != 0)
        {
            anim.SetBool("isMoving", true);
            source.PlayOneShot(clip);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }

}
