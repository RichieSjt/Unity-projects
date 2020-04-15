using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{

    private Rigidbody2D rb;
    public LayerMask platformLayerMask;
    public float speed = 2;
    private float width;
    private bool facingRight;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        width = GetComponent<SpriteRenderer>().bounds.extents.x;
        facingRight = true;
    }

    void Update(){
        if(LevelEditor.isOnEditorMode){
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = Vector3.zero;
            return;
        }
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;

        //Always move formward
        Vector2 myVelocity = rb.velocity;
        myVelocity.x = -transform.right.x * speed;
        rb.velocity = myVelocity;

        if(!isGrounded()){
            Flip();
        }
    }

    private bool isGrounded() {
        Vector2 origin = transform.position - transform.right * width;
        RaycastHit2D groundCheck = Physics2D.Raycast(origin, Vector2.down, 2f, platformLayerMask);
        //Debug.DrawLine(origin, origin + Vector2.down, Color.red);

        return groundCheck.collider != null;
    }

    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

}
