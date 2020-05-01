using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitantController : MonoBehaviour{
    private Rigidbody2D rb;
    private Vector3 shootDirection;
    public float speed = 2f;
    public float lifeSpan = 20f;

    public void Setup(Vector3 shootDirection){
        this.shootDirection = shootDirection;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * speed, ForceMode2D.Impulse);
        Destroy(gameObject, lifeSpan);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            ScoreScript.scoreValue += 100;
            Destroy(gameObject);
        }else if(collision.tag == "Enemy"){
            ScoreScript.scoreValue -= 10;
            Destroy(gameObject);
        }
    }

}
