using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    private Animator anim;

    private HealthSystem healthSystem;
    public HealthBar healthBar;
    public GameObject missilePrefab1;
    public Transform firePoint1;

    private void Start() {

        healthSystem = new HealthSystem(100);
        healthBar.Setup(healthSystem);

        anim = GetComponent<Animator>();
        anim.SetBool("receivesDamage", false);

    }

    void Update() {
        float x = Input.GetAxis("Horizontal") * 0.12f;
        float y = Input.GetAxis("Vertical") * 0.12f;

        gameObject.transform.Translate(new Vector3(x, y, 0));

        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Meteor") {
            
            Meteor meteor = collision.GetComponent<Meteor>();

            healthSystem.TakeDamage(meteor.GetDamage());
            anim.SetBool("receivesDamage", true);
            Invoke("ExitAnimation", 0.2f);

            if (healthSystem.GetHealth() <= 0)
                Destroy(gameObject); 
        }
        if (collision.tag == "EnemyMissile") {
            EnemyMissile missile = collision.GetComponent<EnemyMissile>();

            healthSystem.TakeDamage(missile.GetDamage());
            anim.SetBool("receivesDamage", true);
            Invoke("ExitAnimation", 0.2f);

            if (healthSystem.GetHealth() <= 0)
                Destroy(gameObject);
        }
    }

    private void Shoot() {
        Instantiate(missilePrefab1, firePoint1.position, firePoint1.rotation);
    }

    private void ExitAnimation() {
        anim.SetBool("receivesDamage", false);
    }

}
