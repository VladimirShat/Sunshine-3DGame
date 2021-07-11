using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpForce = 7f;
    public float gravityForce = 18f;

    private Vector3 moveDirection;

    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);

            if (Input.GetButton("Run"))
            {
                moveDirection *= runSpeed;
            }
            else moveDirection *= walkSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y += jumpForce;
            }
                
        }

        moveDirection.y -= gravityForce * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
