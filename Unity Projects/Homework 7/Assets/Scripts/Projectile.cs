using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{

    private Rigidbody2D rb;
    private Vector3 shootDirection;
    public float speed = 20f;
    public int damage = 20;
    public bool enemyShooting = false;
    public bool bigProjectile = false;

    public void Setup(Vector3 shootDirection){
        this.shootDirection = shootDirection;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(shootDirection * speed, ForceMode2D.Impulse);

        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(enemyShooting){
            if (collision.tag == "Player" || collision.tag == "Planet" && !bigProjectile){
                SoundManagerScript.PlaySound("normalHit");
                Destroy(gameObject);
            }else if(collision.tag == "Player" || collision.tag == "Planet" && bigProjectile) {
                SoundManagerScript.PlaySound("bigHit");
                Destroy(gameObject);
            }

        }else{
            if (collision.tag == "Enemy" || collision.tag == "Planet"){
                SoundManagerScript.PlaySound("normalHit");
                Destroy(gameObject);
            }
        }
        
    }
}
