using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector2 input;
    private PlayerStatus status;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        // Ű �Է°��� ���� input �� ����
        if (context.phase == InputActionPhase.Performed)
        {
            input = context.ReadValue<Vector2>();
        }
        else
        {
            input = Vector3.zero;
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
            // Ű �Է�(input)�� ���� �̵�
            Vector3 moveDirection = ((transform.forward * input.y) + (transform.right * input.x)).normalized;

            // ���� ���� ����
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
