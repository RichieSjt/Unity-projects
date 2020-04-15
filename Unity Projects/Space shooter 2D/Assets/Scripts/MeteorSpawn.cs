using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPrefab;
    void Start()
    {
        InvokeRepeating("SpawnMeteor", 0, 2);
    }

    void SpawnMeteor() {
        Vector3 position = gameObject.transform.position;
        position.x = Random.Range(-8, 8);
        gameObject.transform.position = position;
        Instantiate(meteorPrefab, transform.position, Quaternion.identity);

    }
}
