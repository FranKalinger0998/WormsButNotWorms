using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MovementScript : NetworkBehaviour
{

    public float jumpForce = 10;
    public float moveSpeed = 20;
    public bool isPlayerGrounded = true;
    float distToGround;
    private Rigidbody rb;
    public KeyCode forward;
    public KeyCode backwards;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;


    // Start is called before the first frame update
    void Start()
    {
        var collider = GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        if (!IsOwner)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        Movement();
    }

    private void Movement()
    {
        Vector3 movingDirection = Vector3.zero;

        // Jump
        if (Input.GetKeyDown(jump))
        {
            if (IsGrounded())
            {
                
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Reset vertical velocity to prevent jump boost
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }

        // Move forward
        if (Input.GetKey(forward))
        {
            movingDirection += transform.forward * moveSpeed;
            
        }

        // Move backward
        else if (Input.GetKey(backwards))
        {
            movingDirection -= transform.forward * moveSpeed;
           
        }

        // Move left
        else if (Input.GetKey(left))
        {
            movingDirection -= transform.right * moveSpeed;
            
        }

        // Move right
        else if (Input.GetKey(right))
        {
            movingDirection += transform.right * moveSpeed;
           
        }
        

        // Apply movement
        rb.velocity = new Vector3(movingDirection.x, rb.velocity.y, movingDirection.z);



    }

    // Check if the player is grounded
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
