using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 12f;
    private float m_MovementSmoothing = .05f;
    public float jumpVelocity = 50f;
    private bool jump;
    private bool doubleJump;
    private bool facingRight;

    private Vector3 m_Velocity = Vector3.zero;

    private Rigidbody2D rigidbody2D;
    private CircleCollider2D circleCollider2D;
    [SerializeField] private LayerMask platformLayerMask;

    private void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        facingRight = true;
    }
    private void Update(){

        


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            Vector3 targetVelocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
            rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            Vector3 targetVelocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
            rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) ) {
            if (isGrounded()) {
                jump = true;
                doubleJump = true;
            }else if (doubleJump) {
                jump = true;
                doubleJump = false;
            }
        }

        if (jump) {
            rigidbody2D.velocity = Vector2.up * jumpVelocity;
            jump = false;
        }
        if(rigidbody2D.velocity.x > 0 && !facingRight) {
            Flip();
        }
        if(rigidbody2D.velocity.x < 0 && facingRight) {
            Flip();
        }

    }

    private bool isGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(circleCollider2D.bounds.center, circleCollider2D.bounds.size, 0f, Vector2.down, 0.15f, platformLayerMask);
        return raycastHit2D.collider != null;
    }

    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo) {
        
        if(hitInfo.tag == "Spikes" || hitInfo.tag == "Enemy") {
            //Kind of respawn
            transform.position = new Vector3(-5.784f, -3f, 0);
        }
    }

}
