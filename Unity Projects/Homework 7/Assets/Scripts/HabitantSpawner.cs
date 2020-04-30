using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitantSpawner : MonoBehaviour{

    private CircleCollider2D circleCollider;
    public GameObject habitantPrefab;
    private float radius;
    public int numberOfHabitants = 4;

    private void Start() {
        circleCollider = GetComponent<CircleCollider2D>();
        radius = circleCollider.radius + 0.05f;
        InvokeRepeating("GenerateHabitants", 0.5f, 3f);
        
    }

    private Vector3 RandomPositionInCircle(){
        float angle = Random.Range (0f, Mathf.PI * 2);
        float x = Mathf.Sin (angle) * radius;
        float y = Mathf.Cos (angle) * radius;
        return new Vector3(x, y, 0);
    }

    private void GenerateHabitants(){
        for (int i = 0; i < numberOfHabitants; i++){
            Vector3 pos = RandomPositionInCircle();
            Vector3 pos1 = new Vector3(pos.x*2, pos.y*2, 0f);
            Vector3 shootDirection = (pos1 - pos).normalized;
            GameObject habitant = Instantiate(habitantPrefab, pos, Quaternion.identity);
            habitant.GetComponent<HabitantController>().Setup(shootDirection);
        }   
    }
}
