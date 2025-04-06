using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;
    Rigidbody2D rb2d;
    Vector2 moveValue;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(
            Mathf.Clamp(rb2d.linearVelocity.x + moveValue.x*Time.fixedDeltaTime*30, -8f, 8f), 
            rb2d.linearVelocity.y);
        if(moveValue == Vector2.zero)
        {
            rb2d.linearVelocity = rb2d.linearVelocity * 0.9f;
        }

    }

    void OnFire()
    {
        Debug.Log("Fire");
        animator.SetTrigger("Attacking");
    }

    void OnMove(InputValue val)
    {
        moveValue = val.Get<Vector2>();
        animator.SetBool("Moving", moveValue.x != 0);
        if(moveValue.x > 0)
            sr.flipX = false;
        else if(moveValue.x < 0)
            sr.flipX = true;

    }
}
