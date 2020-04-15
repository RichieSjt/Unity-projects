using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Animator anim;

    private HealthSystem healthSystem;
    public int damage = 20;
    public int health = 200;
    public HealthBar healthBar;

    public GameObject missilePrefab1;
    public GameObject missilePrefab2;
    public Transform firePoint1;
    public Transform firePoint2;

    private void Start() {
        healthSystem = new HealthSystem(health);
        healthBar.Setup(healthSystem);
        InvokeRepeating("Shoot", 0, 1.5f);

        anim = GetComponent<Animator>();
        anim.SetBool("receivesDamage", false);
    }

    void Update() {
        gameObject.transform.Translate(new Vector3(0, -0.1f * 0.2f, 0));
    }

    private void Shoot() {
        Instantiate(missilePrefab1, firePoint1.position, firePoint1.rotation);
        Instantiate(missilePrefab2, firePoint2.position, firePoint2.rotation);
    }

    public int GetDamage() {
        return damage; 
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Missile") {
            Missile missile = collision.GetComponent<Missile>();

            anim.SetBool("receivesDamage", true);
            Invoke("ExitAnimation", 0.2f);

            healthSystem.TakeDamage(missile.GetDamage());
            if (healthSystem.GetHealth() <= 0)
                Destroy(gameObject);
        }
    }

    private void ExitAnimation() {
        anim.SetBool("receivesDamage", false);
    }

}
