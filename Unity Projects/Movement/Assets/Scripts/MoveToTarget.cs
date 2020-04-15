using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour{
    public Transform target;
    public float speed = 3.5f;

    void Update(){
        float distance = Vector3.Distance(transform.position, target.position);
        transform.position = Vector3.Lerp(transform.position, target.position, (Time.deltaTime * speed) / distance);
    }

}
