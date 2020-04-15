using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

    private Animator anim;
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider2D;
    public LayerMask platformLayerMask;
    public Transform spawnPos;

    public float speed = 300;
    public float jumpSpeed = 5;
    private bool jump;
    private bool doubleJump;
    private bool facingRight;

    void Start(){
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        facingRight = true;
    }

    private void Update() {
        if(LevelEditor.isOnEditorMode){
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = Vector3.zero;
            return;
        }
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;

        float x = Input.GetAxis("Horizontal");

        float xForce = x * speed * Time.deltaTime;
        float yForce = rb.velocity.y;

        if(x > 0 && !facingRight)
            Flip();
        if(x < 0 && facingRight)
            Flip();

        if(Input.GetKeyDown(KeyCode.Space)){
            if (isGrounded()){
                jump = true;
                doubleJump = true;
            }else if (doubleJump) {
                jump = true;
                doubleJump = false;
            }
        }

        if (jump) {
            yForce = jumpSpeed;
            jump = false;
        }

        if(!isGrounded())
            anim.SetBool("isJumping", true);
        else
            anim.SetBool("isJumping", false);

        Vector2 moveVelocity = new Vector2(xForce, yForce);
        rb.velocity = moveVelocity;

        anim.SetFloat("VelocityX", Mathf.Abs(rb.velocity.x));
    }

    private bool isGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size, 0f, Vector2.down, 0.15f, platformLayerMask);
        return raycastHit2D.collider != null;
    }
    
    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy")
            transform.position = spawnPos.position;   
    }
}
