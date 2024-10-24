using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 moveDirection;
    private PlayerStatus status;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            moveDirection = new Vector3(input.x, 0, input.y).normalized;
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            rigid.AddForce(Vector3.up * status.JumpForce, ForceMode.VelocityChange);
        }
        
    }

    private void Move()
    {
        if (status.CanMove)
        {
            rigid.velocity = new Vector3(moveDirection.x * status.MoveSpeed, rigid.velocity.y, moveDirection.z * status.MoveSpeed);
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        status = GetComponent<PlayerStatus>();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
