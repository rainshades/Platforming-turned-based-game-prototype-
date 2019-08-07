using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PhysicsObject
{
    PlayerActions action;
    Vector2 move;

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        action = new PlayerActions();
    }

    protected override void ComputeVelocity()
    {
        //    Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        //    transform.Translate(m, Space.World);

        action.InputsMap.Walk.performed += ctx => move.x = ctx.ReadValue<Vector2>().x;
        action.InputsMap.Walk.canceled += ctx => move = Vector2.zero;

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