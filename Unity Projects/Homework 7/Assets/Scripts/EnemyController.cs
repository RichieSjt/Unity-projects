using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{
    private Rigidbody2D rb;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform firePointEnd;
    public Transform followTarget;
    private HealthSystem healthSystem;
   
    private Vector3 shootDirection;

    public float speed = 3.0f;
    public float rotationSpeed = 3.0f;
    public float degreesOffset = 0;
    public float stoppingDistance = 1f;
    public float shootRepeat = 1f;
    public bool isBig = false;
    

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Shoot", 0f, shootRepeat);
        healthSystem = GetComponent<HealthSystem>();
        if(!isBig){
            followTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }else{
            followTarget = GameObject.FindGameObjectWithTag("Planet").GetComponent<Transform>();
        }
    }

    void FixedUpdate(){

        Vector3 enemyPos = transform.position;
        Vector3 playerPos = followTarget.position;
        Vector2 movement = Vector2.MoveTowards(enemyPos, playerPos, speed * Time.deltaTime);

        float distanceBetween = Vector2.Distance(enemyPos, playerPos);

        if(distanceBetween > stoppingDistance)
            transform.position = movement;

        //Rotation of the ship
        Vector3 vectorToTarget = followTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle + degreesOffset, transform.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 1000);

        shootDirection = (firePointEnd.position - firePoint.position).normalized;
    }   

    private void Shoot() {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Projectile>().Setup(shootDirection);
        projectile.GetComponent<Projectile>().enemyShooting = true;

        if(isBig){
            SoundManagerScript.PlaySound("bigShoot");
        }else{
            SoundManagerScript.PlaySound("enemyShoot");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.tag == "PlayerProjectile"){  
            Projectile projectile = collision.GetComponent<Projectile>();
            healthSystem.TakeDamage(projectile.damage);

            if(healthSystem.health <= 0){
                Destroy(gameObject);
                if(isBig)
                    ScoreScript.scoreValue += 1000;
                else
                    ScoreScript.scoreValue += 200;
            }

            Debug.Log("Enemy ship Health: " + healthSystem.health);

        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Planet" && !isBig || collision.gameObject.tag == "Player" && !isBig){
            Destroy(gameObject);
            ScoreScript.scoreValue += 20;
        }
    }

}
