using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public bool CanMove { get; private set; }
    public float MoveSpeed { get; private set; }
    public float JumpForce { get; private set; }

    public float HP { get; private set; }


    private void Awake()
    {
        CanMove = true;
        MoveSpeed = 5.0f;
        JumpForce = 5.0f;
        HP = 100.0f;
    }
}
