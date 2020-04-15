using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour{
    public float SpawnSpeed = 1f;
    public GameObject TankPrefab;

    void Start(){
        InvokeRepeating("SpawnTank", 0, SpawnSpeed);
    }
    void SpawnTank() {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(TankPrefab, spawnPos, transform.rotation);
    }

}
