using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public float gravity = -9.8f;
    public Vector3 velocity;
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jump = 180f;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.muerto)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 8;
        }
        else
        {
            speed = 4;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2 * gravity * Time.deltaTime);
        }
    }


}
