using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rigidbody2D;
    private int damage = 20;

    void Start() {
        rigidbody2D.velocity = -transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player" || collision.tag == "Missile")
            Destroy(gameObject);
    }
    public int GetDamage() {
        return damage;
    }

}

