using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    void Start() {
        InvokeRepeating("SpawnEnemy", 0, 4);
    }

    void SpawnEnemy() {
        Vector3 position = gameObject.transform.position;
        position.x = Random.Range(-8, 8);
        gameObject.transform.position = position;
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);

    }
}
