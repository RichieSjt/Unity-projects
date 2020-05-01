using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private Rigidbody2D rb;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public Transform firePointEnd;
    public Transform followPoint;

    public float speed = 3.0f;
    public float rotationSpeed = 3.0f;
    

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        float xAxis = Input.GetAxis("Horizontal");

        Vector3 pos = followPoint.position;
        // Move to point 
        transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        // Rotate with object
        rb.MoveRotation(rb.rotation + (-xAxis * rotationSpeed) * Time.fixedDeltaTime);  
    }   
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 shootDirection = (firePointEnd.position - firePoint.position).normalized;
            Shoot(shootDirection);
        }
    }
    private void Shoot(Vector3 shootDirection) {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Projectile>().Setup(shootDirection);
        SoundManagerScript.PlaySound("normalShoot");
    }
}
