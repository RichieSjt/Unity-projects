using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 15;

    void Start() {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.tag == "Enemy") {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
