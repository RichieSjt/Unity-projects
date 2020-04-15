using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    void Update() {
        Vector3 moveDirection = new Vector3(0,0,0);

        if(Input.GetKeyDown(KeyCode.A))
            moveDirection = Vector3.left;

        if(Input.GetKeyDown(KeyCode.D))
            moveDirection = Vector3.right;
        
        if(Input.GetKeyDown(KeyCode.W))
            moveDirection = Vector3.up;

        if(Input.GetKeyDown(KeyCode.S))
            moveDirection = Vector3.down;
            
        Vector3 targetPosition = transform.position + moveDirection;
        
        LayerMask mask = LayerMask.GetMask("Wall");

        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDirection, 1.05f, mask);
        //Debug.DrawRay(transform.position, moveDirection, Color.blue);

        if(raycastHit.collider == null){
            transform.position = targetPosition;
            Debug.Log("None");
        }else{
            Debug.Log("Some");
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Enemy")
            transform.position = new Vector3(-0.495f, -3.504f, 0f);
    }
}
