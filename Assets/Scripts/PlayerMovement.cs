using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject FootstepsSound;
    public int maxStamina = 200;
    public int currentStamina = 0;
    public float staminaCooldown = 0f;
    public float midStaminaCooldown = 0.5f;
    public float maxStaminaCooldown = 3f;

    static public bool dialogue = false;

    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        FootstepsSound.SetActive(false);
        currentStamina = maxStamina;
        walkSpeed = moveSpeed;
        sprintSpeed = moveSpeed*1.5f;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        if(staminaCooldown <= 0f && !Input.GetKey(jumpKey) && currentStamina < maxStamina)
        {
            moveSpeed = walkSpeed;
            currentStamina++;
        }
        if (Input.GetKey(jumpKey) && currentStamina > 0)
        {
            moveSpeed = sprintSpeed;
            currentStamina--;
            staminaCooldown = midStaminaCooldown;
        }
        if (currentStamina <= 0 && staminaCooldown <=0)
        {
            moveSpeed = walkSpeed;
            staminaCooldown = maxStaminaCooldown;
        }
        staminaCooldown -= Time.deltaTime;
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        if (!dialogue)
        {
            MovePlayer();
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if(horizontalInput != 0 || verticalInput != 0)
        {
            if(FootstepsSound.activeSelf != true)
            {
                FootstepsSound.SetActive(true);
            }
        }
        else
        {
            FootstepsSound.SetActive(false);
        }
        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded && currentStamina>0)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}