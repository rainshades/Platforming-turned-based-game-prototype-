using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerActions action;
    Vector2 move;

    void Awake()
    {
        action = new PlayerActions();
        action.InputsMap.Walk.performed += ctx => move = ctx.ReadValue<Vector2>();
        action.InputsMap.Walk.canceled += ctx => move = Vector2.zero;
    }

    void Walk()
    {
    }

    void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }

    void OnEnable()
    {
        action.InputsMap.Enable();
    }

    void OnDisable()
    {
        action.InputsMap.Disable();
    }

}