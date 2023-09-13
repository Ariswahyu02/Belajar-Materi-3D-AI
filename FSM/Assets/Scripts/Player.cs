using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool onCrouch = false;
    private PlayerControls playerControls;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 input;
    private Animator animator;

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
            playerControls.Movement.Crouch.started += _ => StartCrouching();

            playerControls.Movement.Crouch.canceled += _ => StopCrouching();
    }

    private void Update() {
        ReadInputKey();
        ChangePlayerAnim();

       animator.SetBool("onCrouch", onCrouch);
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + input * (speed * Time.fixedDeltaTime));
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void StartCrouching()
    {
        onCrouch = true;
    }

    private void StopCrouching()
    {
        
        onCrouch = false;
    }

    private void ReadInputKey()
    {
        input = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void ChangePlayerAnim()
    {
        animator.SetFloat("animMoveX", input.x);
        animator.SetFloat("animMoveY", input.y);

        if(input.x > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(input.x < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
