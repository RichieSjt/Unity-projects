using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate;

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.Mouse0)) {
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
