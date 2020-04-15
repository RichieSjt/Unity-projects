using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour{

    private HealthSystem healthSystem;
    private int damage = 50;
    public int health = 100;

    private void Start() {
        healthSystem = new HealthSystem(health);
    }   
    public int GetDamage() {
        return damage;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Missile") {
            Missile missile = collision.GetComponent<Missile>();

            healthSystem.TakeDamage(missile.GetDamage());
            if (healthSystem.GetHealth() <= 0)   
                Destroy(gameObject);
        }
    }
}
