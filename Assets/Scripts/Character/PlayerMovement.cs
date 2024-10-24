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
        // 키 입력값에 따라 input 값 변경
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
            // 키 입력(input)에 대한 이동
            Vector3 moveDirection = ((transform.forward * input.y) + (transform.right * input.x)).normalized;

            // 최종 물리 적용
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
