using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PhysicsObject
{
    Player pete;
    PlayerActions action;
    Vector2 move;

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 0.00001f;

    SpriteRenderer spriteRenderer;
    Animator animator;

    void Awake()
    {
        action = new PlayerActions();

        action.InputsMap.Walk.performed += ctx => move.x = ctx.ReadValue<Vector2>().x;
        action.InputsMap.Walk.canceled += ctx => move = Vector2.zero;
    }

    protected override void ComputeVelocity()
    {
        if (grounded)
        {
            action.InputsMap.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed;
        }
        else
        {
            action.InputsMap.Jump.performed += ctx => velocity.y = 0;
        }//Accedental flutter jump. KEEP IT


        targetVelocity = move * maxSpeed;
    }

    void OnEnable()
    {
        action.InputsMap.Enable();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnDisable()
    {
        action.InputsMap.Disable();
    }
}