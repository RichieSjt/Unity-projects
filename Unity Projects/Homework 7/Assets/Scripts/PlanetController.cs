using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour{

    private HealthSystem healthSystem;

    void Start(){
        healthSystem = GetComponent<HealthSystem>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerProjectile" || collision.tag == "EnemyProjectile"){
            Projectile projectile = collision.GetComponent<Projectile>();
            healthSystem.TakeDamage(projectile.damage);

            if(healthSystem.health <= 0){
                Destroy(gameObject);
            }
            Debug.Log("Planet Health: " + healthSystem.health);

        }
    }

}
