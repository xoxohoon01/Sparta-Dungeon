using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool CanMove { get; private set; }
    public float MoveSpeed { get; private set; }
    public float JumpForce { get; private set; }

    [SerializeField] public float MaxHP = 100;
    [SerializeField] public float HP = 100;


    private void Awake()
    {
        CanMove = true;
        MoveSpeed = 5.0f;
        JumpForce = 5.0f;
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
