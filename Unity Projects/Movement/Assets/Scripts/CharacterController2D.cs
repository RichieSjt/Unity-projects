using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour{
    private Rigidbody2D rigidbody;
    public float moveSpeed = 100;
    public float jumpVelocity = 10;

    void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float xForce = x * moveSpeed * Time.deltaTime;
        float yForce = rigidbody.velocity.y;

        if(Input.GetKeyDown(KeyCode.Space)){
            yForce = jumpVelocity;
        }

        rigidbody.velocity = new Vector2(xForce, yForce);
    }

}
