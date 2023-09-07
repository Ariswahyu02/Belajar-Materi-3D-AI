using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerControls playerControls;
    private Rigidbody2D rb;
    private Vector2 input;

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        ReadInputKey();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + input * (speed * Time.fixedDeltaTime));
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void ReadInputKey()
    {
        input = playerControls.Movement.Move.ReadValue<Vector2>();
    }
}
