using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public GameObject enemyShipPrefab;
    public GameObject enemyWarShipPrefab;
    public float spawnTimer = 25;

    void Start(){
        InvokeRepeating("SpawnEnemy", 0, spawnTimer);
    }

    void SpawnEnemy() {
        int choice = Random.Range(0, 2);

        if(choice == 1)
            Instantiate(enemyShipPrefab, transform.position, Quaternion.identity);
        else if(choice == 0)
            Instantiate(enemyWarShipPrefab, transform.position, Quaternion.identity);
    }

}
