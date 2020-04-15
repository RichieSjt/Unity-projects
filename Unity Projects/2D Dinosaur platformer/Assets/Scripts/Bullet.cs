using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    public float speed = 20f;
    public Rigidbody2D rigidbody2d;
    public int damage = 15;

    void Start() {
        rigidbody2d.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if(hitInfo.tag == "Enemy") {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            enemy.takeDamage(damage);
            Destroy(gameObject);
        } else if(hitInfo.tag == "Bullet") {

        } else {
            Destroy(gameObject);
        }
    }

}
