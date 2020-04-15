using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour{
    
    public Transform[] targets;
    public List<Vector3> targetsPosition = new List<Vector3>();
    public Vector3 currentTarget;

    public int targetIndex;
    public float speed = 3.5f;

    void Start(){
        foreach(var target in targets){
            targetsPosition.Add(target.position);
        }
        SetTarget(targetsPosition[targetIndex]);
    }

    void Update(){
        Move();
    }
    
    void SetTarget(Vector3 target){
        currentTarget = target;
    }

    void Move(){
        float distance = Vector3.Distance(transform.position, currentTarget);
        if(distance <= 0){
            targetIndex++;
            targetIndex = targetIndex % targetsPosition.Count;
            SetTarget(targetsPosition[targetIndex]);
        }else{
            transform.position = Vector3.Lerp(transform.position, currentTarget, (Time.deltaTime * speed) / distance);
        }
    }

}
