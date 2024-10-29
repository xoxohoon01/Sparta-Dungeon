using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool canMove;
    public float moveSpeed;
    public float jumpForce;

    [SerializeField] public float MaxHP = 100;
    [SerializeField] public float HP = 100;


    private void Awake()
    {
        canMove = true;
        moveSpeed = 5.0f;
        jumpForce = 5.0f;
        MaxHP = 100.0f;
        HP = MaxHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HP -= 10;
        }
    }
}
