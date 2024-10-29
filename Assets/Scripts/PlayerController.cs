using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float horizontalSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody playerRigidbody;
    private Animator animator;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardMovement = Vector3.forward * forwardSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + forwardMovement);

        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 horizontalMovement = Vector3.right * horizontalInput * horizontalSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + horizontalMovement);

        float speed=Mathf.Abs(horizontalInput*horizontalSpeed)+ forwardSpeed;
        animator.SetFloat("Speed", speed);

        if(Input.GetButton("Jump")&& isGrounded)
        {
           
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("IsJumping", true);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }
}
