using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Transform target;
    public float speed;
    private Vector3 inicio, fin;

    private void Start() {
        if(target != null) {
            target.parent = null;
            inicio = transform.position;
            fin = target.position;
        }
    }

    private void FixedUpdate() {
        if(target != null) {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);

            
        }
        if(transform.position == target.position) {
            target.position = (target.position == inicio) ? fin : inicio;
            
                transform.Rotate(0f, 180f, 0f);
            
        }
    }

    public void takeDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            die();
        }
    }

    void die() {
        Destroy(gameObject);
    }
    
}
