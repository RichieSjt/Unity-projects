using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    //private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    public LayerMask platformLayerMask;
    public float speed = 300;
    public float jumpSpeed = 5;
    private bool jump;
    private bool facingRight;

    void Start(){
        //anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        facingRight = true;
    }

    private void Update() {
        float x = Input.GetAxis("Horizontal");

        float xForce = x * speed * Time.deltaTime;
        float yForce = rb.velocity.y;

        if(x > 0 && !facingRight)
            Flip();
        if(x < 0 && facingRight)
            Flip();

        if(Input.GetKeyDown(KeyCode.Space)){
            if (isGrounded())
                jump = true;
        }

        if (jump) {
            yForce = jumpSpeed;
            jump = false;
        }

        Vector2 moveVelocity = new Vector2(xForce, yForce);
        rb.velocity = moveVelocity;

        //anim.SetFloat("VelocityX", Mathf.Abs(rb.velocity.x));
    }

    private bool isGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.15f, platformLayerMask);
        return raycastHit2D.collider != null;
    }
    
    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }
}
