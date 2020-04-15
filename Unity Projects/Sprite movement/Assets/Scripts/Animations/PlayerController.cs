using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    public Animator anim;
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public float speed = 10;

    void Start(){
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        float xInput = Input.GetAxis("Horizontal");

        if(xInput < 0)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
        
        float xForce = xInput * speed * Time.deltaTime;
        float yForce = rb.velocity.y;

        Vector2 velocity = new Vector2(xForce, yForce);
        rb.velocity = velocity;

        anim.SetFloat("VelocityX", Mathf.Abs(velocity.x));
    }
}
